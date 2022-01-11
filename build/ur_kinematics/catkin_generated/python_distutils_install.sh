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

echo_and_run cd "/home/uk-ras-mrc/Rosie2.0/src/ur/universal_robot/ur_kinematics"

# ensure that Python install destination exists
echo_and_run mkdir -p "$DESTDIR/home/uk-ras-mrc/Rosie2.0/install/lib/python2.7/dist-packages"

# Note that PYTHONPATH is pulled from the environment to support installing
# into one location when some dependencies were installed in another
# location, #123.
echo_and_run /usr/bin/env \
    PYTHONPATH="/home/uk-ras-mrc/Rosie2.0/install/lib/python2.7/dist-packages:/home/uk-ras-mrc/Rosie2.0/build/ur_kinematics/lib/python2.7/dist-packages:$PYTHONPATH" \
    CATKIN_BINARY_DIR="/home/uk-ras-mrc/Rosie2.0/build/ur_kinematics" \
    "/usr/bin/python2" \
    "/home/uk-ras-mrc/Rosie2.0/src/ur/universal_robot/ur_kinematics/setup.py" \
     \
    build --build-base "/home/uk-ras-mrc/Rosie2.0/build/ur_kinematics" \
    install \
    --root="${DESTDIR-/}" \
    --install-layout=deb --prefix="/home/uk-ras-mrc/Rosie2.0/install" --install-scripts="/home/uk-ras-mrc/Rosie2.0/install/bin"
