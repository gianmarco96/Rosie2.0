execute_process(COMMAND "/home/rosie2/Rosie2.0/build/robotiq_2f_gripper_control/catkin_generated/python_distutils_install.sh" RESULT_VARIABLE res)

if(NOT res EQUAL 0)
  message(FATAL_ERROR "execute_process(/home/rosie2/Rosie2.0/build/robotiq_2f_gripper_control/catkin_generated/python_distutils_install.sh) returned error code ")
endif()
