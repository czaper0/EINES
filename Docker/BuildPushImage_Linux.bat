::docker login -u atomaszewski
:: -p <password>

docker rmi atomaszewski/application:zsutpw-sdn-controlsvc_linux

docker build -f ../ZsutPw.Sdn.ControlSvc/Dockerfile.prod -t atomaszewski/application:zsutpw-sdn-controlsvc_linux ..

docker images

docker image ls --filter label=stage=zsutpw-sdn-controlsvc_build

docker image prune --filter label=stage=zsutpw-sdn-controlsvc_build --force

docker push atomaszewski/application:zsutpw-sdn-controlsvc_linux

docker images

::docker logout

pause
