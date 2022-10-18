


docker kill ndapp


docker image build -t ndapp .


docker container run --rm -it -d --name ndapp --publish 80:80 ndapp

