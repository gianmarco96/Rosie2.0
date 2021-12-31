# generated from genmsg/cmake/pkg-genmsg.cmake.em

message(STATUS "rosie2_test: 0 messages, 1 services")

set(MSG_I_FLAGS "-Igeometry_msgs:/opt/ros/melodic/share/geometry_msgs/cmake/../msg;-Iiiwa_msgs:/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/iiwa_msgs/msg;-Iiiwa_msgs:/home/uk-ras-mrc/Rosie2.0/devel/.private/iiwa_msgs/share/iiwa_msgs/msg;-Imoveit_msgs:/opt/ros/melodic/share/moveit_msgs/cmake/../msg;-Isensor_msgs:/opt/ros/melodic/share/sensor_msgs/cmake/../msg;-Istd_msgs:/opt/ros/melodic/share/std_msgs/cmake/../msg;-Itf2_msgs:/opt/ros/melodic/share/tf2_msgs/cmake/../msg;-Itrajectory_msgs:/opt/ros/melodic/share/trajectory_msgs/cmake/../msg;-Iactionlib_msgs:/opt/ros/melodic/share/actionlib_msgs/cmake/../msg;-Ishape_msgs:/opt/ros/melodic/share/shape_msgs/cmake/../msg;-Iobject_recognition_msgs:/opt/ros/melodic/share/object_recognition_msgs/cmake/../msg;-Ioctomap_msgs:/opt/ros/melodic/share/octomap_msgs/cmake/../msg")

# Find all generators
find_package(gencpp REQUIRED)
find_package(geneus REQUIRED)
find_package(genlisp REQUIRED)
find_package(gennodejs REQUIRED)
find_package(genpy REQUIRED)

add_custom_target(rosie2_test_generate_messages ALL)

# verify that message/service dependencies have not changed since configure



get_filename_component(_filename "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv" NAME_WE)
add_custom_target(_rosie2_test_generate_messages_check_deps_${_filename}
  COMMAND ${CATKIN_ENV} ${PYTHON_EXECUTABLE} ${GENMSG_CHECK_DEPS_SCRIPT} "rosie2_test" "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv" "geometry_msgs/Pose:std_msgs/Header:geometry_msgs/Point:geometry_msgs/Quaternion:geometry_msgs/PoseArray"
)

#
#  langs = gencpp;geneus;genlisp;gennodejs;genpy
#

### Section generating for lang: gencpp
### Generating Messages

### Generating Services
_generate_srv_cpp(rosie2_test
  "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv"
  "${MSG_I_FLAGS}"
  "/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Pose.msg;/opt/ros/melodic/share/std_msgs/cmake/../msg/Header.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Point.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Quaternion.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/PoseArray.msg"
  ${CATKIN_DEVEL_PREFIX}/${gencpp_INSTALL_DIR}/rosie2_test
)

### Generating Module File
_generate_module_cpp(rosie2_test
  ${CATKIN_DEVEL_PREFIX}/${gencpp_INSTALL_DIR}/rosie2_test
  "${ALL_GEN_OUTPUT_FILES_cpp}"
)

add_custom_target(rosie2_test_generate_messages_cpp
  DEPENDS ${ALL_GEN_OUTPUT_FILES_cpp}
)
add_dependencies(rosie2_test_generate_messages rosie2_test_generate_messages_cpp)

# add dependencies to all check dependencies targets
get_filename_component(_filename "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv" NAME_WE)
add_dependencies(rosie2_test_generate_messages_cpp _rosie2_test_generate_messages_check_deps_${_filename})

# target for backward compatibility
add_custom_target(rosie2_test_gencpp)
add_dependencies(rosie2_test_gencpp rosie2_test_generate_messages_cpp)

# register target for catkin_package(EXPORTED_TARGETS)
list(APPEND ${PROJECT_NAME}_EXPORTED_TARGETS rosie2_test_generate_messages_cpp)

### Section generating for lang: geneus
### Generating Messages

### Generating Services
_generate_srv_eus(rosie2_test
  "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv"
  "${MSG_I_FLAGS}"
  "/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Pose.msg;/opt/ros/melodic/share/std_msgs/cmake/../msg/Header.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Point.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Quaternion.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/PoseArray.msg"
  ${CATKIN_DEVEL_PREFIX}/${geneus_INSTALL_DIR}/rosie2_test
)

### Generating Module File
_generate_module_eus(rosie2_test
  ${CATKIN_DEVEL_PREFIX}/${geneus_INSTALL_DIR}/rosie2_test
  "${ALL_GEN_OUTPUT_FILES_eus}"
)

add_custom_target(rosie2_test_generate_messages_eus
  DEPENDS ${ALL_GEN_OUTPUT_FILES_eus}
)
add_dependencies(rosie2_test_generate_messages rosie2_test_generate_messages_eus)

# add dependencies to all check dependencies targets
get_filename_component(_filename "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv" NAME_WE)
add_dependencies(rosie2_test_generate_messages_eus _rosie2_test_generate_messages_check_deps_${_filename})

# target for backward compatibility
add_custom_target(rosie2_test_geneus)
add_dependencies(rosie2_test_geneus rosie2_test_generate_messages_eus)

# register target for catkin_package(EXPORTED_TARGETS)
list(APPEND ${PROJECT_NAME}_EXPORTED_TARGETS rosie2_test_generate_messages_eus)

### Section generating for lang: genlisp
### Generating Messages

### Generating Services
_generate_srv_lisp(rosie2_test
  "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv"
  "${MSG_I_FLAGS}"
  "/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Pose.msg;/opt/ros/melodic/share/std_msgs/cmake/../msg/Header.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Point.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Quaternion.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/PoseArray.msg"
  ${CATKIN_DEVEL_PREFIX}/${genlisp_INSTALL_DIR}/rosie2_test
)

### Generating Module File
_generate_module_lisp(rosie2_test
  ${CATKIN_DEVEL_PREFIX}/${genlisp_INSTALL_DIR}/rosie2_test
  "${ALL_GEN_OUTPUT_FILES_lisp}"
)

add_custom_target(rosie2_test_generate_messages_lisp
  DEPENDS ${ALL_GEN_OUTPUT_FILES_lisp}
)
add_dependencies(rosie2_test_generate_messages rosie2_test_generate_messages_lisp)

# add dependencies to all check dependencies targets
get_filename_component(_filename "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv" NAME_WE)
add_dependencies(rosie2_test_generate_messages_lisp _rosie2_test_generate_messages_check_deps_${_filename})

# target for backward compatibility
add_custom_target(rosie2_test_genlisp)
add_dependencies(rosie2_test_genlisp rosie2_test_generate_messages_lisp)

# register target for catkin_package(EXPORTED_TARGETS)
list(APPEND ${PROJECT_NAME}_EXPORTED_TARGETS rosie2_test_generate_messages_lisp)

### Section generating for lang: gennodejs
### Generating Messages

### Generating Services
_generate_srv_nodejs(rosie2_test
  "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv"
  "${MSG_I_FLAGS}"
  "/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Pose.msg;/opt/ros/melodic/share/std_msgs/cmake/../msg/Header.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Point.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Quaternion.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/PoseArray.msg"
  ${CATKIN_DEVEL_PREFIX}/${gennodejs_INSTALL_DIR}/rosie2_test
)

### Generating Module File
_generate_module_nodejs(rosie2_test
  ${CATKIN_DEVEL_PREFIX}/${gennodejs_INSTALL_DIR}/rosie2_test
  "${ALL_GEN_OUTPUT_FILES_nodejs}"
)

add_custom_target(rosie2_test_generate_messages_nodejs
  DEPENDS ${ALL_GEN_OUTPUT_FILES_nodejs}
)
add_dependencies(rosie2_test_generate_messages rosie2_test_generate_messages_nodejs)

# add dependencies to all check dependencies targets
get_filename_component(_filename "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv" NAME_WE)
add_dependencies(rosie2_test_generate_messages_nodejs _rosie2_test_generate_messages_check_deps_${_filename})

# target for backward compatibility
add_custom_target(rosie2_test_gennodejs)
add_dependencies(rosie2_test_gennodejs rosie2_test_generate_messages_nodejs)

# register target for catkin_package(EXPORTED_TARGETS)
list(APPEND ${PROJECT_NAME}_EXPORTED_TARGETS rosie2_test_generate_messages_nodejs)

### Section generating for lang: genpy
### Generating Messages

### Generating Services
_generate_srv_py(rosie2_test
  "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv"
  "${MSG_I_FLAGS}"
  "/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Pose.msg;/opt/ros/melodic/share/std_msgs/cmake/../msg/Header.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Point.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/Quaternion.msg;/opt/ros/melodic/share/geometry_msgs/cmake/../msg/PoseArray.msg"
  ${CATKIN_DEVEL_PREFIX}/${genpy_INSTALL_DIR}/rosie2_test
)

### Generating Module File
_generate_module_py(rosie2_test
  ${CATKIN_DEVEL_PREFIX}/${genpy_INSTALL_DIR}/rosie2_test
  "${ALL_GEN_OUTPUT_FILES_py}"
)

add_custom_target(rosie2_test_generate_messages_py
  DEPENDS ${ALL_GEN_OUTPUT_FILES_py}
)
add_dependencies(rosie2_test_generate_messages rosie2_test_generate_messages_py)

# add dependencies to all check dependencies targets
get_filename_component(_filename "/home/uk-ras-mrc/Rosie2.0/src/iiwa_stack/rosie2_test/srv/PlanSrv.srv" NAME_WE)
add_dependencies(rosie2_test_generate_messages_py _rosie2_test_generate_messages_check_deps_${_filename})

# target for backward compatibility
add_custom_target(rosie2_test_genpy)
add_dependencies(rosie2_test_genpy rosie2_test_generate_messages_py)

# register target for catkin_package(EXPORTED_TARGETS)
list(APPEND ${PROJECT_NAME}_EXPORTED_TARGETS rosie2_test_generate_messages_py)



if(gencpp_INSTALL_DIR AND EXISTS ${CATKIN_DEVEL_PREFIX}/${gencpp_INSTALL_DIR}/rosie2_test)
  # install generated code
  install(
    DIRECTORY ${CATKIN_DEVEL_PREFIX}/${gencpp_INSTALL_DIR}/rosie2_test
    DESTINATION ${gencpp_INSTALL_DIR}
  )
endif()
if(TARGET geometry_msgs_generate_messages_cpp)
  add_dependencies(rosie2_test_generate_messages_cpp geometry_msgs_generate_messages_cpp)
endif()
if(TARGET iiwa_msgs_generate_messages_cpp)
  add_dependencies(rosie2_test_generate_messages_cpp iiwa_msgs_generate_messages_cpp)
endif()
if(TARGET moveit_msgs_generate_messages_cpp)
  add_dependencies(rosie2_test_generate_messages_cpp moveit_msgs_generate_messages_cpp)
endif()
if(TARGET sensor_msgs_generate_messages_cpp)
  add_dependencies(rosie2_test_generate_messages_cpp sensor_msgs_generate_messages_cpp)
endif()
if(TARGET std_msgs_generate_messages_cpp)
  add_dependencies(rosie2_test_generate_messages_cpp std_msgs_generate_messages_cpp)
endif()
if(TARGET tf2_msgs_generate_messages_cpp)
  add_dependencies(rosie2_test_generate_messages_cpp tf2_msgs_generate_messages_cpp)
endif()
if(TARGET trajectory_msgs_generate_messages_cpp)
  add_dependencies(rosie2_test_generate_messages_cpp trajectory_msgs_generate_messages_cpp)
endif()

if(geneus_INSTALL_DIR AND EXISTS ${CATKIN_DEVEL_PREFIX}/${geneus_INSTALL_DIR}/rosie2_test)
  # install generated code
  install(
    DIRECTORY ${CATKIN_DEVEL_PREFIX}/${geneus_INSTALL_DIR}/rosie2_test
    DESTINATION ${geneus_INSTALL_DIR}
  )
endif()
if(TARGET geometry_msgs_generate_messages_eus)
  add_dependencies(rosie2_test_generate_messages_eus geometry_msgs_generate_messages_eus)
endif()
if(TARGET iiwa_msgs_generate_messages_eus)
  add_dependencies(rosie2_test_generate_messages_eus iiwa_msgs_generate_messages_eus)
endif()
if(TARGET moveit_msgs_generate_messages_eus)
  add_dependencies(rosie2_test_generate_messages_eus moveit_msgs_generate_messages_eus)
endif()
if(TARGET sensor_msgs_generate_messages_eus)
  add_dependencies(rosie2_test_generate_messages_eus sensor_msgs_generate_messages_eus)
endif()
if(TARGET std_msgs_generate_messages_eus)
  add_dependencies(rosie2_test_generate_messages_eus std_msgs_generate_messages_eus)
endif()
if(TARGET tf2_msgs_generate_messages_eus)
  add_dependencies(rosie2_test_generate_messages_eus tf2_msgs_generate_messages_eus)
endif()
if(TARGET trajectory_msgs_generate_messages_eus)
  add_dependencies(rosie2_test_generate_messages_eus trajectory_msgs_generate_messages_eus)
endif()

if(genlisp_INSTALL_DIR AND EXISTS ${CATKIN_DEVEL_PREFIX}/${genlisp_INSTALL_DIR}/rosie2_test)
  # install generated code
  install(
    DIRECTORY ${CATKIN_DEVEL_PREFIX}/${genlisp_INSTALL_DIR}/rosie2_test
    DESTINATION ${genlisp_INSTALL_DIR}
  )
endif()
if(TARGET geometry_msgs_generate_messages_lisp)
  add_dependencies(rosie2_test_generate_messages_lisp geometry_msgs_generate_messages_lisp)
endif()
if(TARGET iiwa_msgs_generate_messages_lisp)
  add_dependencies(rosie2_test_generate_messages_lisp iiwa_msgs_generate_messages_lisp)
endif()
if(TARGET moveit_msgs_generate_messages_lisp)
  add_dependencies(rosie2_test_generate_messages_lisp moveit_msgs_generate_messages_lisp)
endif()
if(TARGET sensor_msgs_generate_messages_lisp)
  add_dependencies(rosie2_test_generate_messages_lisp sensor_msgs_generate_messages_lisp)
endif()
if(TARGET std_msgs_generate_messages_lisp)
  add_dependencies(rosie2_test_generate_messages_lisp std_msgs_generate_messages_lisp)
endif()
if(TARGET tf2_msgs_generate_messages_lisp)
  add_dependencies(rosie2_test_generate_messages_lisp tf2_msgs_generate_messages_lisp)
endif()
if(TARGET trajectory_msgs_generate_messages_lisp)
  add_dependencies(rosie2_test_generate_messages_lisp trajectory_msgs_generate_messages_lisp)
endif()

if(gennodejs_INSTALL_DIR AND EXISTS ${CATKIN_DEVEL_PREFIX}/${gennodejs_INSTALL_DIR}/rosie2_test)
  # install generated code
  install(
    DIRECTORY ${CATKIN_DEVEL_PREFIX}/${gennodejs_INSTALL_DIR}/rosie2_test
    DESTINATION ${gennodejs_INSTALL_DIR}
  )
endif()
if(TARGET geometry_msgs_generate_messages_nodejs)
  add_dependencies(rosie2_test_generate_messages_nodejs geometry_msgs_generate_messages_nodejs)
endif()
if(TARGET iiwa_msgs_generate_messages_nodejs)
  add_dependencies(rosie2_test_generate_messages_nodejs iiwa_msgs_generate_messages_nodejs)
endif()
if(TARGET moveit_msgs_generate_messages_nodejs)
  add_dependencies(rosie2_test_generate_messages_nodejs moveit_msgs_generate_messages_nodejs)
endif()
if(TARGET sensor_msgs_generate_messages_nodejs)
  add_dependencies(rosie2_test_generate_messages_nodejs sensor_msgs_generate_messages_nodejs)
endif()
if(TARGET std_msgs_generate_messages_nodejs)
  add_dependencies(rosie2_test_generate_messages_nodejs std_msgs_generate_messages_nodejs)
endif()
if(TARGET tf2_msgs_generate_messages_nodejs)
  add_dependencies(rosie2_test_generate_messages_nodejs tf2_msgs_generate_messages_nodejs)
endif()
if(TARGET trajectory_msgs_generate_messages_nodejs)
  add_dependencies(rosie2_test_generate_messages_nodejs trajectory_msgs_generate_messages_nodejs)
endif()

if(genpy_INSTALL_DIR AND EXISTS ${CATKIN_DEVEL_PREFIX}/${genpy_INSTALL_DIR}/rosie2_test)
  install(CODE "execute_process(COMMAND \"/usr/bin/python2\" -m compileall \"${CATKIN_DEVEL_PREFIX}/${genpy_INSTALL_DIR}/rosie2_test\")")
  # install generated code
  install(
    DIRECTORY ${CATKIN_DEVEL_PREFIX}/${genpy_INSTALL_DIR}/rosie2_test
    DESTINATION ${genpy_INSTALL_DIR}
  )
endif()
if(TARGET geometry_msgs_generate_messages_py)
  add_dependencies(rosie2_test_generate_messages_py geometry_msgs_generate_messages_py)
endif()
if(TARGET iiwa_msgs_generate_messages_py)
  add_dependencies(rosie2_test_generate_messages_py iiwa_msgs_generate_messages_py)
endif()
if(TARGET moveit_msgs_generate_messages_py)
  add_dependencies(rosie2_test_generate_messages_py moveit_msgs_generate_messages_py)
endif()
if(TARGET sensor_msgs_generate_messages_py)
  add_dependencies(rosie2_test_generate_messages_py sensor_msgs_generate_messages_py)
endif()
if(TARGET std_msgs_generate_messages_py)
  add_dependencies(rosie2_test_generate_messages_py std_msgs_generate_messages_py)
endif()
if(TARGET tf2_msgs_generate_messages_py)
  add_dependencies(rosie2_test_generate_messages_py tf2_msgs_generate_messages_py)
endif()
if(TARGET trajectory_msgs_generate_messages_py)
  add_dependencies(rosie2_test_generate_messages_py trajectory_msgs_generate_messages_py)
endif()
