// Auto-generated. Do not edit!

// (in-package rosie2_test.srv)


"use strict";

const _serializer = _ros_msg_utils.Serialize;
const _arraySerializer = _serializer.Array;
const _deserializer = _ros_msg_utils.Deserialize;
const _arrayDeserializer = _deserializer.Array;
const _finder = _ros_msg_utils.Find;
const _getByteLength = _ros_msg_utils.getByteLength;
let geometry_msgs = _finder('geometry_msgs');

//-----------------------------------------------------------

let std_msgs = _finder('std_msgs');

//-----------------------------------------------------------

class PlanSrvRequest {
  constructor(initObj={}) {
    if (initObj === null) {
      // initObj === null is a special case for deserialization where we don't initialize fields
      this.pose_goal = null;
      this.plan = null;
    }
    else {
      if (initObj.hasOwnProperty('pose_goal')) {
        this.pose_goal = initObj.pose_goal
      }
      else {
        this.pose_goal = new geometry_msgs.msg.PoseArray();
      }
      if (initObj.hasOwnProperty('plan')) {
        this.plan = initObj.plan
      }
      else {
        this.plan = false;
      }
    }
  }

  static serialize(obj, buffer, bufferOffset) {
    // Serializes a message object of type PlanSrvRequest
    // Serialize message field [pose_goal]
    bufferOffset = geometry_msgs.msg.PoseArray.serialize(obj.pose_goal, buffer, bufferOffset);
    // Serialize message field [plan]
    bufferOffset = _serializer.bool(obj.plan, buffer, bufferOffset);
    return bufferOffset;
  }

  static deserialize(buffer, bufferOffset=[0]) {
    //deserializes a message object of type PlanSrvRequest
    let len;
    let data = new PlanSrvRequest(null);
    // Deserialize message field [pose_goal]
    data.pose_goal = geometry_msgs.msg.PoseArray.deserialize(buffer, bufferOffset);
    // Deserialize message field [plan]
    data.plan = _deserializer.bool(buffer, bufferOffset);
    return data;
  }

  static getMessageSize(object) {
    let length = 0;
    length += geometry_msgs.msg.PoseArray.getMessageSize(object.pose_goal);
    return length + 1;
  }

  static datatype() {
    // Returns string type for a service object
    return 'rosie2_test/PlanSrvRequest';
  }

  static md5sum() {
    //Returns md5sum for a message object
    return '9e59f9886b1a5776ac4cab26e76f900b';
  }

  static messageDefinition() {
    // Returns full string definition for message
    return `
    geometry_msgs/PoseArray pose_goal
    bool plan
    
    ================================================================================
    MSG: geometry_msgs/PoseArray
    # An array of poses with a header for global reference.
    
    Header header
    
    Pose[] poses
    
    ================================================================================
    MSG: std_msgs/Header
    # Standard metadata for higher-level stamped data types.
    # This is generally used to communicate timestamped data 
    # in a particular coordinate frame.
    # 
    # sequence ID: consecutively increasing ID 
    uint32 seq
    #Two-integer timestamp that is expressed as:
    # * stamp.sec: seconds (stamp_secs) since epoch (in Python the variable is called 'secs')
    # * stamp.nsec: nanoseconds since stamp_secs (in Python the variable is called 'nsecs')
    # time-handling sugar is provided by the client library
    time stamp
    #Frame this data is associated with
    string frame_id
    
    ================================================================================
    MSG: geometry_msgs/Pose
    # A representation of pose in free space, composed of position and orientation. 
    Point position
    Quaternion orientation
    
    ================================================================================
    MSG: geometry_msgs/Point
    # This contains the position of a point in free space
    float64 x
    float64 y
    float64 z
    
    ================================================================================
    MSG: geometry_msgs/Quaternion
    # This represents an orientation in free space in quaternion form.
    
    float64 x
    float64 y
    float64 z
    float64 w
    
    `;
  }

  static Resolve(msg) {
    // deep-construct a valid message object instance of whatever was passed in
    if (typeof msg !== 'object' || msg === null) {
      msg = {};
    }
    const resolved = new PlanSrvRequest(null);
    if (msg.pose_goal !== undefined) {
      resolved.pose_goal = geometry_msgs.msg.PoseArray.Resolve(msg.pose_goal)
    }
    else {
      resolved.pose_goal = new geometry_msgs.msg.PoseArray()
    }

    if (msg.plan !== undefined) {
      resolved.plan = msg.plan;
    }
    else {
      resolved.plan = false
    }

    return resolved;
    }
};

class PlanSrvResponse {
  constructor(initObj={}) {
    if (initObj === null) {
      // initObj === null is a special case for deserialization where we don't initialize fields
      this.feedback = null;
    }
    else {
      if (initObj.hasOwnProperty('feedback')) {
        this.feedback = initObj.feedback
      }
      else {
        this.feedback = new std_msgs.msg.String();
      }
    }
  }

  static serialize(obj, buffer, bufferOffset) {
    // Serializes a message object of type PlanSrvResponse
    // Serialize message field [feedback]
    bufferOffset = std_msgs.msg.String.serialize(obj.feedback, buffer, bufferOffset);
    return bufferOffset;
  }

  static deserialize(buffer, bufferOffset=[0]) {
    //deserializes a message object of type PlanSrvResponse
    let len;
    let data = new PlanSrvResponse(null);
    // Deserialize message field [feedback]
    data.feedback = std_msgs.msg.String.deserialize(buffer, bufferOffset);
    return data;
  }

  static getMessageSize(object) {
    let length = 0;
    length += std_msgs.msg.String.getMessageSize(object.feedback);
    return length;
  }

  static datatype() {
    // Returns string type for a service object
    return 'rosie2_test/PlanSrvResponse';
  }

  static md5sum() {
    //Returns md5sum for a message object
    return 'be452bdb25132e643f85b55a53a6b2e3';
  }

  static messageDefinition() {
    // Returns full string definition for message
    return `
    std_msgs/String feedback
    
    
    ================================================================================
    MSG: std_msgs/String
    string data
    
    `;
  }

  static Resolve(msg) {
    // deep-construct a valid message object instance of whatever was passed in
    if (typeof msg !== 'object' || msg === null) {
      msg = {};
    }
    const resolved = new PlanSrvResponse(null);
    if (msg.feedback !== undefined) {
      resolved.feedback = std_msgs.msg.String.Resolve(msg.feedback)
    }
    else {
      resolved.feedback = new std_msgs.msg.String()
    }

    return resolved;
    }
};

module.exports = {
  Request: PlanSrvRequest,
  Response: PlanSrvResponse,
  md5sum() { return 'bc5ea13bd95c2618bb349c7e46d2ed2b'; },
  datatype() { return 'rosie2_test/PlanSrv'; }
};
