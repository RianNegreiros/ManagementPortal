PROJECT_NAME ?= ManagementPortal
ORG_NAME ?= ManagementPortal
REPO_NAME ?= ManagementPortal

.PHONY: migrations db

migrations:
	cd ./ManagementPortal.Data && dotnet ef --startup-project ../ManagementPortal.web/ migrations add $(name) && cd ..

db:
	cd ./ManagementPortal.Data && dotnet ef --startup-project ../ManagementPortal.web/ database update && cd ..