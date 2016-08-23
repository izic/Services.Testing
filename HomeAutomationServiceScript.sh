#!/bin/bash

PROGRAM_NAME="Host"
LOCK_FILE="/tmp/"${PROGRAM_NAME}".lock"
 
usage()
{
    echo "$0 (start|stop)"
}
 
stop()
{
    if [ -e ${LOCK_FILE} ]
    then
        _pid=$(cat ${LOCK_FILE})
        kill $_pid
        rt=$?
        if [ "$rt" == "0" ]
	        then
	                echo "Demon stop"
	        else
	                echo "Error stop demon"
        fi
    else
        echo "Demon is not running"
    fi
}
 
start()
{
    echo "Demon starting"
    mono-service -l:${LOCK_FILE} ./${PROGRAM_NAME}.exe
    echo "Demon started"
}
 
case $1 in
    "start")
            start
            ;;
    "stop")
            stop
            ;;
    *)
            usage
            ;;
esac
exit