import flask
import os
import ast
import json
import threading
#import test
from flask import send_from_directory, request, render_template
'''
###################### ROS stuff ############################
'''
import rospy
from std_msgs.msg import String

fulfillmentString = 'some Google response'
var = json.dumps({'fulfillmentText': 'fulfillmentString'})


def callback(data):
    global fulfillmentString
    fulfillmentString = data.data
    var = json.dumps({'fulfillmentText': data.data})
    #print(json.dumps({'fulfillmentText': data.data}))
    

# Creating a second thread that will handle the ROS node
threading.Thread(target=lambda: rospy.init_node('example_node', disable_signals=True)).start()

rospy.Subscriber("/google_response", String, callback)
#global fulfillmentHandler
fulfillmentHandler = rospy.Publisher("fulfillmentHandler", String, queue_size=True)



'''
###################### ROS stuff ############################
'''

app = flask.Flask(__name__)

@app.route('/favicon.ico')
def favicon():
    return send_from_directory(os.path.join(app.root_path, 'static'),
                               'favicon.ico', mimetype='image/favicon.png')

@app.route('/')
@app.route('/home')
def home():
    return "Hello World! "

@app.route('/webhook', methods=['POST'])
def webhook():
    global fulfillmentString
    global req
    req = request.get_json(force=True)
    req = (req)['queryResult']['intent']['displayName']
    fulfillmentHandler.publish(str(req))
    return json.dumps({'fulfillmentText': fulfillmentString})
    

if __name__ == "__main__":
    
    app.secret_key = 'ItIsASecret'
    app.debug = True
    app.run()
    rospy.spin()

    
