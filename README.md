# Formula1API

Ahnaf Ahmad

ENDPOINTS:

GET All Cars:
https://localhost:7090/Formula1Car

POST New Car:
https://localhost:7090/Formula1Car

{
  "id": int32,
  "carId": string,
  "team": string,
  "year": int32
}

GET Car by ID:
https://localhost:7090/Formula1Car/{id=int32}


PUT Car by ID:
https://localhost:7090/Formula1Car/{id=int32}

{
  "id": int32,
  "carId": string,
  "team": string,
  "year": int32
}

GET All Drivers:
https://localhost:7090/Formula1Driver

POST Formula 1 Driver:
https://localhost:7090/Formula1Driver
{
  "id": int32,
  "name": string,
  "number": int32,
  "team": string,
  "carId": int32
}

GET Formula 1 Driver by ID:
https://localhost:7090/Formula1Driver/{id=int32}

PUT Formula 1 Driver by ID:
https://localhost:7090/Formula1Driver/{id=int32}

CHANGES MADE TO API IDEA:

Major downscales applied to the idea. It is now just a functional backend worker for a data-base. It acts more as informational storage than the forecast model I had intended. Problems with getting the data-base to work locally as well as dynamically getting data from other APIs forced the project to be downscaled. 