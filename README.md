# webapiCore-k8
POC to get webapi core with docker image deployed in K8

## Pre-requisites

1. Docker hub installed
2. Docker K8 enabled (kubectl will be installed when K8 is enabled)
3. .Net Core 3.1 installed
4. dotnet cli installed

## Run the app
Open a terminal and go the root path of the project, then run:

1. `dotnet restore`
2. `dotnet run` or hit F5 if you are in VSCode/Studio

Go to http://localhost/health to get the health probe

## Build Docker image
In a terminal, run:

* `docker build -t poc-webapik8:v1`
* `docker images` (to validate the image has been created)

## Run API using Docker image
In a terminal, run `docker run -it --rm -p 8080:80 poc-webapik8:v1`. To stop it, use `ctrl+c`

## Deploy into K8
In a terminal run, in the project's root:

* `kubectl create -f deploy.yml`
* `kubectl create -f public-service.yml`
* `kubectl describe service poc-service` and take note of the NodePort port and the public IP of the cluster

In a browser or postman, go to: `http://{nodeIP}:{nodePort}`

### Service type
In `public-service.yml` the type was set to `NodePort` for: 1) simplicity of the POC, 2) this is intented to be run locally, if its going to be used in a cloud provider, then use `LoadBalancer`
