::docker login -u atomaszewski

docker ps -a

docker stop controlsvc

docker ps 

docker images

::docker pull atomaszewski/application:zsutpw-sdn-controlsvc

docker run --name controlsvc -p 5000:80 -it atomaszewski/application:zsutpw-sdn-controlsvc

pause

docker stop controlsvc

docker rm controlsvc

pause
