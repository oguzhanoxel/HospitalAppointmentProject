# HospitalAppointmentProject

#####  Table of Contents

- [ Overview](#-overview)
- [ Repository Structure](#-repository-structure)
- [ Modules](#-modules)

---

##  Overview

<code>❯The **HospitalAppointmentProject** is a web-based system that allows hospitals to manage appointments, enabling patients to schedule visits with doctors. The project is built using the .NET</code>

---

##  Repository Structure

```sh
└── HospitalAppointmentProject/
    ├── HospitalAppointmentProject.sln
    └── src
        ├── CorePackages
        └── HospitalAppointmentProject
```

## Modules

<details closed><summary>HospitalAppointmentProject.sln</summary>

| File | Summary |
| --- | --- |
| [HospitalAppointmentProject.sln](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/HospitalAppointmentProject.sln) | Solution file for the project, defining all projects and configurations. |

</details>

<details closed><summary>src.CorePackages.Core.Application</summary>

| File | Summary |
| --- | --- |
| [Core.Application.csproj](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Application/Core.Application.csproj) | Project definition for application-level logic and business services. |

</details>

<details closed><summary>src.CorePackages.Core.Application.Results.Concretes</summary>

| File | Summary |
| --- | --- |
| [Result.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Application/Results/Concretes/Result.cs) | Defines the base structure for service result responses. |
| [DataResult.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Application/Results/Concretes/DataResult.cs) | Result class that also carries data along with the response. |

</details>

<details closed><summary>src.CorePackages.Core.Application.Results.Abstracts</summary>

| File | Summary |
| --- | --- |
| [IDataResult.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Application/Results/Abstracts/IDataResult.cs) | Interface for results that include data. |
| [IResult.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Application/Results/Abstracts/IResult.cs) | Interface for basic service results. |

</details>

<details closed><summary>src.CorePackages.Core.Persistence</summary>

| File | Summary |
| --- | --- |
| [Core.Persistence.csproj](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Persistence/Core.Persistence.csproj) | Project for managing database persistence logic and repository patterns. |

</details>

<details closed><summary>src.CorePackages.Core.Persistence.Repositories</summary>

| File | Summary |
| --- | --- |
| [Entity.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Persistence/Repositories/Entity.cs) | Base class for all entities in the system, representing database objects. |
| [EfRepositoryBase.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Persistence/Repositories/EfRepositoryBase.cs) | Generic repository implementing CRUD operations using Entity Framework. |
| [IRepository.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/CorePackages/Core.Persistence/Repositories/IRepository.cs) | Interface for a generic repository, providing common data access methods. |

</details>

<details closed><summary>src.HospitalAppointmentProject.WebAPI</summary>

| File | Summary |
| --- | --- |
| [WebAPI.http](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/WebAPI.http) | Collection of sample HTTP requests for testing the API. |
| [WebAPI.csproj](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/WebAPI.csproj) | Web API project setup and configurations. |
| [appsettings.Development.json](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/appsettings.Development.json) | Configuration settings for the development environment. |
| [appsettings.json](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/appsettings.json) | master configuration file for database and other settings. |
| [Program.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/Program.cs) | Entry point for the Web API, containing the app startup logic. |

</details>

<details closed><summary>src.HospitalAppointmentProject.WebAPI.Controllers</summary>

| File | Summary |
| --- | --- |
| [AppointmentsController.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/Controllers/AppointmentsController.cs) | API controller to handle appointment-related HTTP requests. |
| [DoctorsController.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/Controllers/DoctorsController.cs) | API controller to manage doctor data and operations. |
| [PatientsController.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/Controllers/PatientsController.cs) | API controller to handle patient-related operations. |

</details>

<details closed><summary>src.HospitalAppointmentProject.WebAPI.Properties</summary>

| File | Summary |
| --- | --- |
| [launchSettings.json](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/WebAPI/Properties/launchSettings.json) | Configuration for launching and debugging the Web API locally. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Application</summary>

| File | Summary |
| --- | --- |
| [Application.csproj](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Application.csproj) | Project definition for business logic and application services. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Application.Services.PatientService</summary>

| File | Summary |
| --- | --- |
| [PatientService.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/PatientService/PatientService.cs) | Service class implementing logic for managing patients. |
| [IPatientService.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/PatientService/IPatientService.cs) | Interface for patient-related business services. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Application.Services.PatientService.Dtos</summary>

| File | Summary |
| --- | --- |
| [CreatePatientDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/PatientService/Dtos/CreatePatientDto.cs) | Data Transfer Object for creating a new patient. |
| [DeletePatientDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/PatientService/Dtos/DeletePatientDto.cs) | DTO for deleting an existing patient. |
| [UpdatePatientDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/PatientService/Dtos/UpdatePatientDto.cs) | DTO for updating patient details. |
| [ResponsePatientDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/PatientService/Dtos/ResponsePatientDto.cs) | DTO for sending back patient data in responses. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Application.Services.AppointmentService</summary>

| File | Summary |
| --- | --- |
| [IAppointmentService.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/AppointmentService/IAppointmentService.cs) | Interface for managing appointment-related operations. |
| [AppointmentService.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/AppointmentService/AppointmentService.cs) | Implements business logic for handling appointments. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Application.Services.AppointmentService.Dtos</summary>

| File | Summary |
| --- | --- |
| [ResponseAppointmentDetailsDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/AppointmentService/Dtos/ResponseAppointmentDetailsDto.cs) | DTO for returning detailed information about appointments. |
| [CreateAppointmentDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/AppointmentService/Dtos/CreateAppointmentDto.cs) | DTO for creating a new appointment. |
| [UpdateAppointmentDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/AppointmentService/Dtos/UpdateAppointmentDto.cs) | DTO for updating appointment details. |
| [DeleteAppointmentDto.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/AppointmentService/Dtos/DeleteAppointmentDto.cs) | DTO for deleting an appointment. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Application.Services.Repositories</summary>

| File | Summary |
| --- | --- |
| [IDoctorRepository.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/Repositories/IDoctorRepository.cs) | Repository interface for managing doctor entities. |
| [IPatientRepository.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/Repositories/IPatientRepository.cs) | Repository interface for managing patient entities. |
| [IAppointmentRepository.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Application/Services/Repositories/IAppointmentRepository.cs) | Repository interface for managing appointment entities. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Persistence</summary>

| File | Summary |
| --- | --- |
| [Persistence.csproj](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Persistence/Persistence.csproj) | Project for database access and persistence logic. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Persistence.Repositories</summary>

| File | Summary |
| --- | --- |
| [DoctorRepository.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Persistence/Repositories/DoctorRepository.cs) | Repository for managing doctor data in the database. |
| [AppointmentRepository.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Persistence/Repositories/AppointmentRepository.cs) | Repository for managing appointment data. |
| [PatientRepository.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Persistence/Repositories/PatientRepository.cs) | Repository for managing patient data. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Persistence.Contexts</summary>

| File | Summary |
| --- | --- |
| [InMemoryDbContext.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Persistence/Contexts/InMemoryDbContext.cs) | Context for in-memory database testing. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Domain</summary>

| File | Summary |
| --- | --- |
| [Domain.csproj](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Domain/Domain.csproj) | Project containing Domain entities and logic. |

</details>

<details closed><summary>src.HospitalAppointmentProject.Domain.Entities</summary>

| File | Summary |
| --- | --- |
| [Appointment.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Domain/Entities/Appointment.cs) | Domain model for the appointment entity. |
| [Doctor.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Domain/Entities/Doctor.cs) | Domain model for the doctor entity. |
| [Patient.cs](https://github.com/oguzhanoxel/HospitalAppointmentProject/blob/master/src/HospitalAppointmentProject/Domain/Entities/Patient.cs) | Domain model for the patient entity. |

</details>
