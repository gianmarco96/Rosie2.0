// Generated by gencpp from file rosie2_test/PlanSrv.msg
// DO NOT EDIT!


#ifndef ROSIE2_TEST_MESSAGE_PLANSRV_H
#define ROSIE2_TEST_MESSAGE_PLANSRV_H

#include <ros/service_traits.h>


#include <rosie2_test/PlanSrvRequest.h>
#include <rosie2_test/PlanSrvResponse.h>


namespace rosie2_test
{

struct PlanSrv
{

typedef PlanSrvRequest Request;
typedef PlanSrvResponse Response;
Request request;
Response response;

typedef Request RequestType;
typedef Response ResponseType;

}; // struct PlanSrv
} // namespace rosie2_test


namespace ros
{
namespace service_traits
{


template<>
struct MD5Sum< ::rosie2_test::PlanSrv > {
  static const char* value()
  {
    return "bc5ea13bd95c2618bb349c7e46d2ed2b";
  }

  static const char* value(const ::rosie2_test::PlanSrv&) { return value(); }
};

template<>
struct DataType< ::rosie2_test::PlanSrv > {
  static const char* value()
  {
    return "rosie2_test/PlanSrv";
  }

  static const char* value(const ::rosie2_test::PlanSrv&) { return value(); }
};


// service_traits::MD5Sum< ::rosie2_test::PlanSrvRequest> should match
// service_traits::MD5Sum< ::rosie2_test::PlanSrv >
template<>
struct MD5Sum< ::rosie2_test::PlanSrvRequest>
{
  static const char* value()
  {
    return MD5Sum< ::rosie2_test::PlanSrv >::value();
  }
  static const char* value(const ::rosie2_test::PlanSrvRequest&)
  {
    return value();
  }
};

// service_traits::DataType< ::rosie2_test::PlanSrvRequest> should match
// service_traits::DataType< ::rosie2_test::PlanSrv >
template<>
struct DataType< ::rosie2_test::PlanSrvRequest>
{
  static const char* value()
  {
    return DataType< ::rosie2_test::PlanSrv >::value();
  }
  static const char* value(const ::rosie2_test::PlanSrvRequest&)
  {
    return value();
  }
};

// service_traits::MD5Sum< ::rosie2_test::PlanSrvResponse> should match
// service_traits::MD5Sum< ::rosie2_test::PlanSrv >
template<>
struct MD5Sum< ::rosie2_test::PlanSrvResponse>
{
  static const char* value()
  {
    return MD5Sum< ::rosie2_test::PlanSrv >::value();
  }
  static const char* value(const ::rosie2_test::PlanSrvResponse&)
  {
    return value();
  }
};

// service_traits::DataType< ::rosie2_test::PlanSrvResponse> should match
// service_traits::DataType< ::rosie2_test::PlanSrv >
template<>
struct DataType< ::rosie2_test::PlanSrvResponse>
{
  static const char* value()
  {
    return DataType< ::rosie2_test::PlanSrv >::value();
  }
  static const char* value(const ::rosie2_test::PlanSrvResponse&)
  {
    return value();
  }
};

} // namespace service_traits
} // namespace ros

#endif // ROSIE2_TEST_MESSAGE_PLANSRV_H
