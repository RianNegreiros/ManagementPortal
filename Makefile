PROJECT_NAME ?= ManagementPortal
ORG_NAME ?= ManagementPortal
REPO_NAME ?= ManagementPortal

.PHONY: migrations db

migrations:
	cd ./ManagementPortal.Data && dotnet ef --startup-project ../ManagementPortal.Web/ migrations add $(name) && cd ..

db:
	cd ./ManagementPortal.Data && dotnet ef --startup-project ../ManagementPortal.Web/ database update && cd ..