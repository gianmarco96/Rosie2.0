
(cl:in-package :asdf)

(defsystem "rosie2_test-srv"
  :depends-on (:roslisp-msg-protocol :roslisp-utils :geometry_msgs-msg
)
  :components ((:file "_package")
    (:file "PlanSrv" :depends-on ("_package_PlanSrv"))
    (:file "_package_PlanSrv" :depends-on ("_package"))
  ))