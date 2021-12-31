// Generated by gencpp from file robotiq_2f_gripper_control/UnityGripperResponse.msg
// DO NOT EDIT!


#ifndef ROBOTIQ_2F_GRIPPER_CONTROL_MESSAGE_UNITYGRIPPERRESPONSE_H
#define ROBOTIQ_2F_GRIPPER_CONTROL_MESSAGE_UNITYGRIPPERRESPONSE_H


#include <string>
#include <vector>
#include <map>

#include <ros/types.h>
#include <ros/serialization.h>
#include <ros/builtin_message_traits.h>
#include <ros/message_operations.h>


namespace robotiq_2f_gripper_control
{
template <class ContainerAllocator>
struct UnityGripperResponse_
{
  typedef UnityGripperResponse_<ContainerAllocator> Type;

  UnityGripperResponse_()
    : gripper_state()  {
    }
  UnityGripperResponse_(const ContainerAllocator& _alloc)
    : gripper_state(_alloc)  {
  (void)_alloc;
    }



   typedef std::basic_string<char, std::char_traits<char>, typename ContainerAllocator::template rebind<char>::other >  _gripper_state_type;
  _gripper_state_type gripper_state;





  typedef boost::shared_ptr< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> > Ptr;
  typedef boost::shared_ptr< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> const> ConstPtr;

}; // struct UnityGripperResponse_

typedef ::robotiq_2f_gripper_control::UnityGripperResponse_<std::allocator<void> > UnityGripperResponse;

typedef boost::shared_ptr< ::robotiq_2f_gripper_control::UnityGripperResponse > UnityGripperResponsePtr;
typedef boost::shared_ptr< ::robotiq_2f_gripper_control::UnityGripperResponse const> UnityGripperResponseConstPtr;

// constants requiring out of line definition



template<typename ContainerAllocator>
std::ostream& operator<<(std::ostream& s, const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> & v)
{
ros::message_operations::Printer< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >::stream(s, "", v);
return s;
}


template<typename ContainerAllocator1, typename ContainerAllocator2>
bool operator==(const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator1> & lhs, const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator2> & rhs)
{
  return lhs.gripper_state == rhs.gripper_state;
}

template<typename ContainerAllocator1, typename ContainerAllocator2>
bool operator!=(const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator1> & lhs, const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator2> & rhs)
{
  return !(lhs == rhs);
}


} // namespace robotiq_2f_gripper_control

namespace ros
{
namespace message_traits
{





template <class ContainerAllocator>
struct IsFixedSize< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
  : FalseType
  { };

template <class ContainerAllocator>
struct IsFixedSize< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> const>
  : FalseType
  { };

template <class ContainerAllocator>
struct IsMessage< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
  : TrueType
  { };

template <class ContainerAllocator>
struct IsMessage< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> const>
  : TrueType
  { };

template <class ContainerAllocator>
struct HasHeader< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
  : FalseType
  { };

template <class ContainerAllocator>
struct HasHeader< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> const>
  : FalseType
  { };


template<class ContainerAllocator>
struct MD5Sum< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
{
  static const char* value()
  {
    return "8e18dd67c0dc955135b296c7abccdd08";
  }

  static const char* value(const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator>&) { return value(); }
  static const uint64_t static_value1 = 0x8e18dd67c0dc9551ULL;
  static const uint64_t static_value2 = 0x35b296c7abccdd08ULL;
};

template<class ContainerAllocator>
struct DataType< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
{
  static const char* value()
  {
    return "robotiq_2f_gripper_control/UnityGripperResponse";
  }

  static const char* value(const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator>&) { return value(); }
};

template<class ContainerAllocator>
struct Definition< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
{
  static const char* value()
  {
    return "string gripper_state\n"
"\n"
;
  }

  static const char* value(const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator>&) { return value(); }
};

} // namespace message_traits
} // namespace ros

namespace ros
{
namespace serialization
{

  template<class ContainerAllocator> struct Serializer< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
  {
    template<typename Stream, typename T> inline static void allInOne(Stream& stream, T m)
    {
      stream.next(m.gripper_state);
    }

    ROS_DECLARE_ALLINONE_SERIALIZER
  }; // struct UnityGripperResponse_

} // namespace serialization
} // namespace ros

namespace ros
{
namespace message_operations
{

template<class ContainerAllocator>
struct Printer< ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator> >
{
  template<typename Stream> static void stream(Stream& s, const std::string& indent, const ::robotiq_2f_gripper_control::UnityGripperResponse_<ContainerAllocator>& v)
  {
    s << indent << "gripper_state: ";
    Printer<std::basic_string<char, std::char_traits<char>, typename ContainerAllocator::template rebind<char>::other > >::stream(s, indent + "  ", v.gripper_state);
  }
};

} // namespace message_operations
} // namespace ros

#endif // ROBOTIQ_2F_GRIPPER_CONTROL_MESSAGE_UNITYGRIPPERRESPONSE_H
