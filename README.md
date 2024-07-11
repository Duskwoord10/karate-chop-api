# KarateChop API

The KarateChop API provides a binary search implementation accessible via a RESTful API.

## Prerequisites

- Docker

## Installation

You can pull the Docker image from this repository or build it locally.

### Building the Docker Image

To build the Docker image locally, navigate to the root directory of the project (where the Dockerfile is located) and run the following command:

```sh
docker build -t karatechopapi:latest .
```

## Running the API

Once you have the Docker image, you can run the API using the following command:

```sh
docker run -d -p 8080:8080 -p 8081:8081 --name karatechopapi karatechopapi:latest
```

This command maps port 8080 and 8081 of your host machine to the container's ports 8080 and 8081, respectively.

### Stopping the API

To stop the running container, use the following command:

```sh
docker stop karatechopapi
```

### Removing the Container

To remove the container, use the following command:

```sh
docker rm karatechopapi
```

## API Endpoints

### Swagger UI

To see Swagger UI for endpoint exploration navigate to:

```
http://localhost:8080/swagger/
```

### Welcome Endpoint

You can check if the API is running by navigating to:

```
http://localhost:8080/
```

You should see:

```
Welcome to KarateChop API!
```

### Search Endpoint

To perform a binary search, use the following endpoint:

```
http://localhost:8080/chop?target=7&array=1,3,5,7,9,11,13,15
```

#### Parameters

- `target`: The integer value to search for in the array.
- `array`: A comma-separated list of integers to search within.

#### Responses

- **200 OK**:
  ```json
  {
      "Message": "Target 7 found at index 3.",
      "Index": 3
  }
  ```

- **404 Not Found**:
  ```json
  {
      "Message": "Target 7 not found in the array."
  }
  ```

- **400 Bad Request**:
  ```json
  {
      "Message": "Invalid query parameters. Ensure you provide 'target' and 'array' query parameters."
  }
  ```

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.
