;; Auto-generated. Do not edit!


(when (boundp 'rosie2_test::PlanSrv)
  (if (not (find-package "ROSIE2_TEST"))
    (make-package "ROSIE2_TEST"))
  (shadow 'PlanSrv (find-package "ROSIE2_TEST")))
(unless (find-package "ROSIE2_TEST::PLANSRV")
  (make-package "ROSIE2_TEST::PLANSRV"))
(unless (find-package "ROSIE2_TEST::PLANSRVREQUEST")
  (make-package "ROSIE2_TEST::PLANSRVREQUEST"))
(unless (find-package "ROSIE2_TEST::PLANSRVRESPONSE")
  (make-package "ROSIE2_TEST::PLANSRVRESPONSE"))

(in-package "ROS")

(if (not (find-package "GEOMETRY_MSGS"))
  (ros::roseus-add-msgs "geometry_msgs"))




(defclass rosie2_test::PlanSrvRequest
  :super ros::object
  :slots (_pose_goal ))

(defmethod rosie2_test::PlanSrvRequest
  (:init
   (&key
    ((:pose_goal __pose_goal) (instance geometry_msgs::PoseArray :init))
    )
   (send-super :init)
   (setq _pose_goal __pose_goal)
   self)
  (:pose_goal
   (&rest __pose_goal)
   (if (keywordp (car __pose_goal))
       (send* _pose_goal __pose_goal)
     (progn
       (if __pose_goal (setq _pose_goal (car __pose_goal)))
       _pose_goal)))
  (:serialization-length
   ()
   (+
    ;; geometry_msgs/PoseArray _pose_goal
    (send _pose_goal :serialization-length)
    ))
  (:serialize
   (&optional strm)
   (let ((s (if strm strm
              (make-string-output-stream (send self :serialization-length)))))
     ;; geometry_msgs/PoseArray _pose_goal
       (send _pose_goal :serialize s)
     ;;
     (if (null strm) (get-output-stream-string s))))
  (:deserialize
   (buf &optional (ptr- 0))
   ;; geometry_msgs/PoseArray _pose_goal
     (send _pose_goal :deserialize buf ptr-) (incf ptr- (send _pose_goal :serialization-length))
   ;;
   self)
  )

(defclass rosie2_test::PlanSrvResponse
  :super ros::object
  :slots (_success ))

(defmethod rosie2_test::PlanSrvResponse
  (:init
   (&key
    ((:success __success) nil)
    )
   (send-super :init)
   (setq _success __success)
   self)
  (:success
   (&optional __success)
   (if __success (setq _success __success)) _success)
  (:serialization-length
   ()
   (+
    ;; bool _success
    1
    ))
  (:serialize
   (&optional strm)
   (let ((s (if strm strm
              (make-string-output-stream (send self :serialization-length)))))
     ;; bool _success
       (if _success (write-byte -1 s) (write-byte 0 s))
     ;;
     (if (null strm) (get-output-stream-string s))))
  (:deserialize
   (buf &optional (ptr- 0))
   ;; bool _success
     (setq _success (not (= 0 (sys::peek buf ptr- :char)))) (incf ptr- 1)
   ;;
   self)
  )

(defclass rosie2_test::PlanSrv
  :super ros::object
  :slots ())

(setf (get rosie2_test::PlanSrv :md5sum-) "7c453fc64b64c06915f81b28f9408fd6")
(setf (get rosie2_test::PlanSrv :datatype-) "rosie2_test/PlanSrv")
(setf (get rosie2_test::PlanSrv :request) rosie2_test::PlanSrvRequest)
(setf (get rosie2_test::PlanSrv :response) rosie2_test::PlanSrvResponse)

(defmethod rosie2_test::PlanSrvRequest
  (:response () (instance rosie2_test::PlanSrvResponse :init)))

(setf (get rosie2_test::PlanSrvRequest :md5sum-) "7c453fc64b64c06915f81b28f9408fd6")
(setf (get rosie2_test::PlanSrvRequest :datatype-) "rosie2_test/PlanSrvRequest")
(setf (get rosie2_test::PlanSrvRequest :definition-)
      "geometry_msgs/PoseArray pose_goal

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
---
bool success

")

(setf (get rosie2_test::PlanSrvResponse :md5sum-) "7c453fc64b64c06915f81b28f9408fd6")
(setf (get rosie2_test::PlanSrvResponse :datatype-) "rosie2_test/PlanSrvResponse")
(setf (get rosie2_test::PlanSrvResponse :definition-)
      "geometry_msgs/PoseArray pose_goal

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
---
bool success

")



(provide :rosie2_test/PlanSrv "7c453fc64b64c06915f81b28f9408fd6")


