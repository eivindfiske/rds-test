@echo off

:: Kill running instance of container
docker kill ndapp

:: Builds image specified in Dockerfile
docker image build -t ndapp .

:: Starts container with web application and maps port 80 (ext) to 80 (internal)
docker container run --rm -it -d --name ndapp --publish 80:80 ndapp

echo.
echo "Link: http://localhost:80/"
echo.

pause
