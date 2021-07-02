#!/bin/sh

if [ -n "$DESTDIR" ] ; then
    case $DESTDIR in
        /*) # ok
            ;;
        *)
            /bin/echo "DESTDIR argument must be absolute... "
            /bin/echo "otherwise python's distutils will bork things."
            exit 1
    esac
fi

echo_and_run() { echo "+ $@" ; "$@" ; }

echo_and_run cd "/home/rosie2/Rosie2.0/src/robotiq/robotiq_modbus_rtu"

# ensure that Python install destination exists
echo_and_run mkdir -p "$DESTDIR/home/rosie2/Rosie2.0/install/lib/python2.7/dist-packages"

# Note that PYTHONPATH is pulled from the environment to support installing
# into one location when some dependencies were installed in another
# location, #123.
echo_and_run /usr/bin/env \
    PYTHONPATH="/home/rosie2/Rosie2.0/install/lib/python2.7/dist-packages:/home/rosie2/Rosie2.0/build/robotiq_modbus_rtu/lib/python2.7/dist-packages:$PYTHONPATH" \
    CATKIN_BINARY_DIR="/home/rosie2/Rosie2.0/build/robotiq_modbus_rtu" \
    "/usr/bin/python2" \
    "/home/rosie2/Rosie2.0/src/robotiq/robotiq_modbus_rtu/setup.py" \
     \
    build --build-base "/home/rosie2/Rosie2.0/build/robotiq_modbus_rtu" \
    install \
    --root="${DESTDIR-/}" \
    --install-layout=deb --prefix="/home/rosie2/Rosie2.0/install" --install-scripts="/home/rosie2/Rosie2.0/install/bin"
