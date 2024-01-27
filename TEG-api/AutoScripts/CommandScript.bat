@echo off

REM Example: .\CommandScript.bat ".\CQRS\Commands\Create\User" "Good Example" 
REM - The first part of the script needs to have the exact location of the script specified in order to be executed

REM Inputs
if "%~1"=="" (
    echo Please, input route and class name
    exit /b 1
)

if "%2"=="" (
    echo Please, input class name
    exit /b 1
)

REM Path
set "targetPath=%~1"
set "className=%2"

REM Agregar comillas dobles a las rutas y nombres de clase si contienen espacios
set "targetPath=%targetPath:"=%"
set "className=%className:"=%"

REM Check Path
if not exist "%targetPath%" (
    echo The specified path does not exist.
    exit /b 1
)

REM Convert Path to Namespace
set "namespacePath=%targetPath:\=.%"

REM Create "Class"Command.cs
(
    echo using MediatR;
    echo.namespace TEG_api.CQRS.Commands.%namespacePath% {
    echo.    public class %className%Command : IRequest^</*Response*/^> {
    echo.        public string Example { get; set; }
    echo.    }
    echo.}
) > "%targetPath%\%className%Command.cs"

REM Create "Class"Handler.cs
(
    echo using MediatR;
    echo using TEG_api.Data;
    echo using TEG_api.Services.Interface;
    echo using AutoMapper;
    echo.namespace TEG_api.CQRS.Commands.%namespacePath%
    echo {
    echo    public class %className%Handler : IRequestHandler^<%className%Command, /*Response*/^> {
    echo        private readonly TEGContext _db;
    echo        private readonly ICRUDService _crudService;
    echo        private readonly IMapper _mapper;
    echo.
    echo.       public %className%Handler(TEGContext db^, ICRUDService crudService^, IMapper mapper^) {
    echo            _db = db;
    echo            _crudService = crudService;
    echo            _mapper = mapper;
    echo.       }
    echo.
    echo    }
    echo.}
) > "%targetPath%\%className%Handler.cs"

REM Create "Class"Validator.cs
(
    echo using FluentValidation;
    echo using TEG_api.Data;
    echo.namespace TEG_api.CQRS.Commands.%namespacePath%
    echo {
    echo    public class %className%Validator : AbstractValidator^<%className%Command^> {
    echo        private readonly TEGContext _db;
    echo.
    echo        public %className%Validator(TEGContext db^) {
    echo.            RuleFor(x =^> x.Example^).NotEmpty(^).WithMessage("Example can't be empty"^);
    echo            _db = db;
    echo        }
    echo    }
    echo.}
) > "%targetPath%\%className%Validator.cs"

echo Files generated successfully for the class %className% in the path %targetPath%.
