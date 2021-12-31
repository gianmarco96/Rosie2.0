; Auto-generated. Do not edit!


(cl:in-package rosie2_test-srv)


;//! \htmlinclude PlanSrv-request.msg.html

(cl:defclass <PlanSrv-request> (roslisp-msg-protocol:ros-message)
  ((pose_goal
    :reader pose_goal
    :initarg :pose_goal
    :type geometry_msgs-msg:PoseArray
    :initform (cl:make-instance 'geometry_msgs-msg:PoseArray)))
)

(cl:defclass PlanSrv-request (<PlanSrv-request>)
  ())

(cl:defmethod cl:initialize-instance :after ((m <PlanSrv-request>) cl:&rest args)
  (cl:declare (cl:ignorable args))
  (cl:unless (cl:typep m 'PlanSrv-request)
    (roslisp-msg-protocol:msg-deprecation-warning "using old message class name rosie2_test-srv:<PlanSrv-request> is deprecated: use rosie2_test-srv:PlanSrv-request instead.")))

(cl:ensure-generic-function 'pose_goal-val :lambda-list '(m))
(cl:defmethod pose_goal-val ((m <PlanSrv-request>))
  (roslisp-msg-protocol:msg-deprecation-warning "Using old-style slot reader rosie2_test-srv:pose_goal-val is deprecated.  Use rosie2_test-srv:pose_goal instead.")
  (pose_goal m))
(cl:defmethod roslisp-msg-protocol:serialize ((msg <PlanSrv-request>) ostream)
  "Serializes a message object of type '<PlanSrv-request>"
  (roslisp-msg-protocol:serialize (cl:slot-value msg 'pose_goal) ostream)
)
(cl:defmethod roslisp-msg-protocol:deserialize ((msg <PlanSrv-request>) istream)
  "Deserializes a message object of type '<PlanSrv-request>"
  (roslisp-msg-protocol:deserialize (cl:slot-value msg 'pose_goal) istream)
  msg
)
(cl:defmethod roslisp-msg-protocol:ros-datatype ((msg (cl:eql '<PlanSrv-request>)))
  "Returns string type for a service object of type '<PlanSrv-request>"
  "rosie2_test/PlanSrvRequest")
(cl:defmethod roslisp-msg-protocol:ros-datatype ((msg (cl:eql 'PlanSrv-request)))
  "Returns string type for a service object of type 'PlanSrv-request"
  "rosie2_test/PlanSrvRequest")
(cl:defmethod roslisp-msg-protocol:md5sum ((type (cl:eql '<PlanSrv-request>)))
  "Returns md5sum for a message object of type '<PlanSrv-request>"
  "7c453fc64b64c06915f81b28f9408fd6")
(cl:defmethod roslisp-msg-protocol:md5sum ((type (cl:eql 'PlanSrv-request)))
  "Returns md5sum for a message object of type 'PlanSrv-request"
  "7c453fc64b64c06915f81b28f9408fd6")
(cl:defmethod roslisp-msg-protocol:message-definition ((type (cl:eql '<PlanSrv-request>)))
  "Returns full string definition for message of type '<PlanSrv-request>"
  (cl:format cl:nil "geometry_msgs/PoseArray pose_goal~%~%================================================================================~%MSG: geometry_msgs/PoseArray~%# An array of poses with a header for global reference.~%~%Header header~%~%Pose[] poses~%~%================================================================================~%MSG: std_msgs/Header~%# Standard metadata for higher-level stamped data types.~%# This is generally used to communicate timestamped data ~%# in a particular coordinate frame.~%# ~%# sequence ID: consecutively increasing ID ~%uint32 seq~%#Two-integer timestamp that is expressed as:~%# * stamp.sec: seconds (stamp_secs) since epoch (in Python the variable is called 'secs')~%# * stamp.nsec: nanoseconds since stamp_secs (in Python the variable is called 'nsecs')~%# time-handling sugar is provided by the client library~%time stamp~%#Frame this data is associated with~%string frame_id~%~%================================================================================~%MSG: geometry_msgs/Pose~%# A representation of pose in free space, composed of position and orientation. ~%Point position~%Quaternion orientation~%~%================================================================================~%MSG: geometry_msgs/Point~%# This contains the position of a point in free space~%float64 x~%float64 y~%float64 z~%~%================================================================================~%MSG: geometry_msgs/Quaternion~%# This represents an orientation in free space in quaternion form.~%~%float64 x~%float64 y~%float64 z~%float64 w~%~%~%"))
(cl:defmethod roslisp-msg-protocol:message-definition ((type (cl:eql 'PlanSrv-request)))
  "Returns full string definition for message of type 'PlanSrv-request"
  (cl:format cl:nil "geometry_msgs/PoseArray pose_goal~%~%================================================================================~%MSG: geometry_msgs/PoseArray~%# An array of poses with a header for global reference.~%~%Header header~%~%Pose[] poses~%~%================================================================================~%MSG: std_msgs/Header~%# Standard metadata for higher-level stamped data types.~%# This is generally used to communicate timestamped data ~%# in a particular coordinate frame.~%# ~%# sequence ID: consecutively increasing ID ~%uint32 seq~%#Two-integer timestamp that is expressed as:~%# * stamp.sec: seconds (stamp_secs) since epoch (in Python the variable is called 'secs')~%# * stamp.nsec: nanoseconds since stamp_secs (in Python the variable is called 'nsecs')~%# time-handling sugar is provided by the client library~%time stamp~%#Frame this data is associated with~%string frame_id~%~%================================================================================~%MSG: geometry_msgs/Pose~%# A representation of pose in free space, composed of position and orientation. ~%Point position~%Quaternion orientation~%~%================================================================================~%MSG: geometry_msgs/Point~%# This contains the position of a point in free space~%float64 x~%float64 y~%float64 z~%~%================================================================================~%MSG: geometry_msgs/Quaternion~%# This represents an orientation in free space in quaternion form.~%~%float64 x~%float64 y~%float64 z~%float64 w~%~%~%"))
(cl:defmethod roslisp-msg-protocol:serialization-length ((msg <PlanSrv-request>))
  (cl:+ 0
     (roslisp-msg-protocol:serialization-length (cl:slot-value msg 'pose_goal))
))
(cl:defmethod roslisp-msg-protocol:ros-message-to-list ((msg <PlanSrv-request>))
  "Converts a ROS message object to a list"
  (cl:list 'PlanSrv-request
    (cl:cons ':pose_goal (pose_goal msg))
))
;//! \htmlinclude PlanSrv-response.msg.html

(cl:defclass <PlanSrv-response> (roslisp-msg-protocol:ros-message)
  ((success
    :reader success
    :initarg :success
    :type cl:boolean
    :initform cl:nil))
)

(cl:defclass PlanSrv-response (<PlanSrv-response>)
  ())

(cl:defmethod cl:initialize-instance :after ((m <PlanSrv-response>) cl:&rest args)
  (cl:declare (cl:ignorable args))
  (cl:unless (cl:typep m 'PlanSrv-response)
    (roslisp-msg-protocol:msg-deprecation-warning "using old message class name rosie2_test-srv:<PlanSrv-response> is deprecated: use rosie2_test-srv:PlanSrv-response instead.")))

(cl:ensure-generic-function 'success-val :lambda-list '(m))
(cl:defmethod success-val ((m <PlanSrv-response>))
  (roslisp-msg-protocol:msg-deprecation-warning "Using old-style slot reader rosie2_test-srv:success-val is deprecated.  Use rosie2_test-srv:success instead.")
  (success m))
(cl:defmethod roslisp-msg-protocol:serialize ((msg <PlanSrv-response>) ostream)
  "Serializes a message object of type '<PlanSrv-response>"
  (cl:write-byte (cl:ldb (cl:byte 8 0) (cl:if (cl:slot-value msg 'success) 1 0)) ostream)
)
(cl:defmethod roslisp-msg-protocol:deserialize ((msg <PlanSrv-response>) istream)
  "Deserializes a message object of type '<PlanSrv-response>"
    (cl:setf (cl:slot-value msg 'success) (cl:not (cl:zerop (cl:read-byte istream))))
  msg
)
(cl:defmethod roslisp-msg-protocol:ros-datatype ((msg (cl:eql '<PlanSrv-response>)))
  "Returns string type for a service object of type '<PlanSrv-response>"
  "rosie2_test/PlanSrvResponse")
(cl:defmethod roslisp-msg-protocol:ros-datatype ((msg (cl:eql 'PlanSrv-response)))
  "Returns string type for a service object of type 'PlanSrv-response"
  "rosie2_test/PlanSrvResponse")
(cl:defmethod roslisp-msg-protocol:md5sum ((type (cl:eql '<PlanSrv-response>)))
  "Returns md5sum for a message object of type '<PlanSrv-response>"
  "7c453fc64b64c06915f81b28f9408fd6")
(cl:defmethod roslisp-msg-protocol:md5sum ((type (cl:eql 'PlanSrv-response)))
  "Returns md5sum for a message object of type 'PlanSrv-response"
  "7c453fc64b64c06915f81b28f9408fd6")
(cl:defmethod roslisp-msg-protocol:message-definition ((type (cl:eql '<PlanSrv-response>)))
  "Returns full string definition for message of type '<PlanSrv-response>"
  (cl:format cl:nil "bool success~%~%~%~%"))
(cl:defmethod roslisp-msg-protocol:message-definition ((type (cl:eql 'PlanSrv-response)))
  "Returns full string definition for message of type 'PlanSrv-response"
  (cl:format cl:nil "bool success~%~%~%~%"))
(cl:defmethod roslisp-msg-protocol:serialization-length ((msg <PlanSrv-response>))
  (cl:+ 0
     1
))
(cl:defmethod roslisp-msg-protocol:ros-message-to-list ((msg <PlanSrv-response>))
  "Converts a ROS message object to a list"
  (cl:list 'PlanSrv-response
    (cl:cons ':success (success msg))
))
(cl:defmethod roslisp-msg-protocol:service-request-type ((msg (cl:eql 'PlanSrv)))
  'PlanSrv-request)
(cl:defmethod roslisp-msg-protocol:service-response-type ((msg (cl:eql 'PlanSrv)))
  'PlanSrv-response)
(cl:defmethod roslisp-msg-protocol:ros-datatype ((msg (cl:eql 'PlanSrv)))
  "Returns string type for a service object of type '<PlanSrv>"
  "rosie2_test/PlanSrv")