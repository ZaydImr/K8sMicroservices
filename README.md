# Microservices Architecture Documentation

## Overview

This documentation provides an overview of the microservices architecture implemented using .NET Core 8.0.3 and Kubernetes. The architecture consists of two microservices: `auth-service` and `weather-service`. 

## Microservices

### Auth-Service

- **Description**: Implements Domain-Driven Design (DDD) and Clean Architecture principles.
- **Technology Stack**:
  - Language: C# with .NET Core 8.0.3
  - Database: OracleDB
  - Authentication: Microsoft Identity with JWT
- **Endpoints**:
  - `/register`: Register a new user
  - `/login`: Authenticate user and generate JWT token
  - `/refreshToken`: Refresh JWT token

### Weather-Service

- **Description**: Implements basic weather functionality.
- **Technology Stack**:
  - Language: C# with .NET Core 8.0.3
  - Authentication: JWT
- **Endpoints**:
  - `/WeatherForecast`: Get list of weathers

## Kubernetes Configuration

### Auth-Service

- **Deployment**: Deployed as a Kubernetes Deployment.
- **Service**: Exposed via a Kubernetes Service for internal communication.
- **Ingress**: Configured to route external traffic to the service.
- **Certificates**: Utilizes cert-manager for SSL certificates.

### Weather-Service

- **Deployment**: Deployed as a Kubernetes Deployment.
- **Service**: Exposed via a Kubernetes Service for internal communication.
- **Ingress**: Configured to route external traffic to the service.
- **Certificates**: Utilizes cert-manager for SSL certificates.

## GitHub Actions Workflows

### Development Workflow

- **Description**: This workflow runs on the `main` branch and is triggered on every pull request.
- **Actions**:
  - Builds the application to check for errors.
  - Runs tests to ensure code integrity.

### Production deployment Workflow

- **Description**: This workflow is responsible for deploying the microservices to Kubernetes.
- **Actions**:
  - Builds Docker images for each microservice.
  - Pushes Docker images to a container registry.
  - Applies Kubernetes manifests for each microservice (`auth-service` and `weather-service`).
  - Verifies deployment and service availability.

## Dependencies

- **Oracle**: Used by `auth-service` for data storage.
- **Microsoft Identity**: Used for authentication in `auth-service`.
- **JWT**: Utilized for token-based authentication in both microservices.
- **Kubernetes**: Orchestration platform for deploying and managing microservices.

## Future Improvements

- Implement logging and monitoring for better observability.
- Enhance security measures such as RBAC for Kubernetes resources.
- Scale microservices horizontally based on load.

## Conclusion

This documentation outlines the architecture, technology stack, Kubernetes configuration, deployment process, dependencies, and future improvements for the microservices implemented using .NET Core 8.0.3 and Kubernetes.

