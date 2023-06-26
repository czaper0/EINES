::docker login -u atomaszewski

docker ps -a

docker stop controlsvc

docker ps 

docker images

docker pull atomaszewski/application:zsutpw-sdn-controlsvc_linux

docker run --name controlsvc -p 5000:80 -it atomaszewski/application:zsutpw-sdn-controlsvc_linux

pause

docker stop controlsvc

docker rm controlsvc

pause
