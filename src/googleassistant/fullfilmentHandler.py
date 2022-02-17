#!/usr/bin/env python3

import rospy
import json
import ast
from std_msgs.msg import String

def callback(data):
    jsonStuff = ast.literal_eval(data.data)
    print(jsonStuff['queryResult']['intent']['displayName'])
    handleJson(str(jsonStuff['queryResult']['intent']['displayName'])


def handleJson(data):


fulfillmentString = ''
rospy.Subscriber("/fulfillmentHandler", String, callback)
rospy.init_node('fulfillment_hdlr_node', disable_signals=True)



if __name__ == "__main__":
    print("Started fulfillmentHandler")
    rospy.spin()