::docker login -u atomaszewski
:: -p <password>

docker rmi atomaszewski/application:zsutpw-sdn-controlsvc_dev

docker build -f ../ZsutPw.Sdn.ControlSvc/Dockerfile.dev -t atomaszewski/application:zsutpw-sdn-controlsvc_dev ..

docker images

docker image ls --filter label=stage=zsutpw-sdn-controlsvc_dev_build

docker image prune --filter label=stage=zsutpw-sdn-controlsvc_dev_build --force

docker push atomaszewski/application:zsutpw-sdn-controlsvc_dev

docker images

::docker logout

pause
