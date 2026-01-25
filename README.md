# Annuity-Schedule-Calculation/Investment-Interest-Calculator (Advanced Architecture)

### Technical Task: 
Enterprise-Grade Future Interest Calculation System

### Problem Statement:
The objective was to develop a high-precision computational module for calculating total future interest payments under an investment agreement. The system simulates a business loan scenario with a fixed monthly annuity repayment model, where interest is calculated based on the declining outstanding principal.

### Technical Requirements:
* **Platform**: Developed using .NET Core 2.2 (implemented during its initial release cycle).
* **Input Data**: The module processes Agreement Date, Calculation Date, Investment Amount (X), Annual Interest Rate (R), and Duration in years (N).
* **Core Features**: Developed using .NET Core 2.2 (implemented during its initial release cycle).
* Calculation of total future interest from a specific Calculation Date until the end of the term.
* Implementation of an Annuity Schedule where the monthly payment is constant.
* Dynamic interest calculation based on the current Outstanding Principal.

### Architecture & Engineering Standards (from Solution):
* **Command-Driven Design**: Implemented a custom Command Bus (ICommandBus) and dedicated handlers (e.g., LoanCalculationHandler) to decouple financial intent from execution.
* **Clean Architecture**: Strict separation of concerns between Domain (Entities & Repository Abstractions), Infrastructure (BUS & Data Access), and Application (Services & Models) layers.
* **Generic Repository Pattern**: Used IRepository<T> for data abstraction, ensuring the system is database-agnostic and highly maintainable.
* **Layered Data Flow**: Utilized AutoMapper profiles (e.g., LoanRequestToLoanProfile) to manage transformations between Domain Entities, DTOs (ScheduleDto), and ViewModels.
* **Financial Precision**: All monetary calculations utilize the decimal type to ensure absolute accuracy in investment projections.
* **Test-Driven Foundation**: Core logic is supported by a dedicated Unit Test project to validate annuity formulas and repayment schedules.

### Implementation Specifics:
* **Single Entry Point**: The system features a well-defined interface (ICommandBus / ICalculationService) that accepts input arguments and returns the result, as per the technical requirements.
* **Maintainability**: The project structure follows strict maintainability principles, facilitating easy updates to financial logic or infrastructure.

### Estimated Effort:
* Typically takes 8–12 hours to complete, depending on the complexity of the financial edge cases and UI implementation.

### Result:
<img width="1981" height="951" alt="image" src="https://github.com/user-attachments/assets/b9b14329-f225-40cd-b007-8457eefdd3ea" />
