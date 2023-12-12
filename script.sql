CREATE TABLE "Cohort" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Cohort" PRIMARY KEY AUTOINCREMENT,
    "Type" INTEGER NOT NULL,
    "Periods" INTEGER NOT NULL,
    "StartDate" TEXT NOT NULL,
    "Modality" INTEGER NOT NULL,
    "HasAgreement" INTEGER NOT NULL
);


CREATE TABLE "Leader" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Leader" PRIMARY KEY AUTOINCREMENT,
    "Type" TEXT NOT NULL,
    "Price" TEXT NOT NULL
);


CREATE TABLE "Program" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Program" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Modality" TEXT NOT NULL
);


CREATE TABLE "Student" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Student" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Document" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Phone" TEXT NOT NULL,
    "Address" TEXT NOT NULL,
    "Code" TEXT NOT NULL
);


CREATE TABLE "Expense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Expense" PRIMARY KEY AUTOINCREMENT,
    "Total" REAL NOT NULL,
    "CohortModelId" INTEGER NULL,
    CONSTRAINT "FK_Expense_Cohort_CohortModelId" FOREIGN KEY ("CohortModelId") REFERENCES "Cohort" ("Id")
);


CREATE TABLE "Teacher" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Teacher" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "LeaderId" INTEGER NOT NULL,
    "ProgramModelId" INTEGER NULL,
    CONSTRAINT "FK_Teacher_Leader_LeaderId" FOREIGN KEY ("LeaderId") REFERENCES "Leader" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Teacher_Program_ProgramModelId" FOREIGN KEY ("ProgramModelId") REFERENCES "Program" ("Id")
);


CREATE TABLE "Discount" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Discount" PRIMARY KEY AUTOINCREMENT,
    "Percentage" TEXT NOT NULL,
    "Cost" TEXT NOT NULL,
    "Type" TEXT NOT NULL,
    "StudentModelId" INTEGER NULL,
    CONSTRAINT "FK_Discount_Student_StudentModelId" FOREIGN KEY ("StudentModelId") REFERENCES "Student" ("Id")
);


CREATE TABLE "RegistrationModel" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_RegistrationModel" PRIMARY KEY AUTOINCREMENT,
    "Amount" TEXT NOT NULL,
    "StudentId" INTEGER NOT NULL,
    "CohortModelId" INTEGER NULL,
    CONSTRAINT "FK_RegistrationModel_Cohort_CohortModelId" FOREIGN KEY ("CohortModelId") REFERENCES "Cohort" ("Id"),
    CONSTRAINT "FK_RegistrationModel_Student_StudentId" FOREIGN KEY ("StudentId") REFERENCES "Student" ("Id") ON DELETE CASCADE
);


CREATE TABLE "FixedExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_FixedExpense" PRIMARY KEY AUTOINCREMENT,
    "Criterion" TEXT NOT NULL,
    "UnitValue" TEXT NOT NULL,
    "Quantity" INTEGER NOT NULL,
    "TypeCost" TEXT NOT NULL,
    CONSTRAINT "FK_FixedExpense_Expense_Id" FOREIGN KEY ("Id") REFERENCES "Expense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "RecurrentCost" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_RecurrentCost" PRIMARY KEY AUTOINCREMENT,
    "UnitName" TEXT NOT NULL,
    "HourlyRate" TEXT NOT NULL,
    "NumberHours" INTEGER NOT NULL,
    CONSTRAINT "FK_RecurrentCost_Expense_Id" FOREIGN KEY ("Id") REFERENCES "Expense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "ServiceExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_ServiceExpense" PRIMARY KEY AUTOINCREMENT,
    "ServiceName" TEXT NOT NULL,
    "ServiceType" TEXT NOT NULL,
    "ServiceCost" TEXT NOT NULL,
    CONSTRAINT "FK_ServiceExpense_Expense_Id" FOREIGN KEY ("Id") REFERENCES "Expense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "SpecialExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_SpecialExpense" PRIMARY KEY AUTOINCREMENT,
    "TypeService" TEXT NOT NULL,
    "DescriptionService" TEXT NOT NULL,
    "PercentageService" TEXT NOT NULL,
    "CostService" TEXT NOT NULL,
    CONSTRAINT "FK_SpecialExpense_Expense_Id" FOREIGN KEY ("Id") REFERENCES "Expense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "TravelExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TravelExpense" PRIMARY KEY AUTOINCREMENT,
    "Destination" TEXT NOT NULL,
    "NumberPeople" INTEGER NOT NULL,
    "TransportCost" TEXT NOT NULL,
    "TravelCost" TEXT NOT NULL,
    "NumberTravel" INTEGER NOT NULL,
    CONSTRAINT "FK_TravelExpense_Expense_Id" FOREIGN KEY ("Id") REFERENCES "Expense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "SubjectModel" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_SubjectModel" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Modality" INTEGER NOT NULL,
    "TeacherId" INTEGER NOT NULL,
    "RegistrationModelId" INTEGER NULL,
    CONSTRAINT "FK_SubjectModel_RegistrationModel_RegistrationModelId" FOREIGN KEY ("RegistrationModelId") REFERENCES "RegistrationModel" ("Id"),
    CONSTRAINT "FK_SubjectModel_Teacher_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teacher" ("Id") ON DELETE CASCADE
);


CREATE TABLE "GeneralExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_GeneralExpense" PRIMARY KEY AUTOINCREMENT,
    CONSTRAINT "FK_GeneralExpense_FixedExpense_Id" FOREIGN KEY ("Id") REFERENCES "FixedExpense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "OtherExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_OtherExpense" PRIMARY KEY AUTOINCREMENT,
    CONSTRAINT "FK_OtherExpense_FixedExpense_Id" FOREIGN KEY ("Id") REFERENCES "FixedExpense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "OtherServiceNonTeachingStaff" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_OtherServiceNonTeachingStaff" PRIMARY KEY AUTOINCREMENT,
    "UnitCostService" TEXT NOT NULL,
    "QuantityService" INTEGER NOT NULL,
    CONSTRAINT "FK_OtherServiceNonTeachingStaff_ServiceExpense_Id" FOREIGN KEY ("Id") REFERENCES "ServiceExpense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "OtherServiceTeachingStaff" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_OtherServiceTeachingStaff" PRIMARY KEY AUTOINCREMENT,
    "DescriptionService" TEXT NOT NULL,
    "TeacherName" TEXT NOT NULL,
    "NumberHoursService" INTEGER NOT NULL,
    "CostHourlyService" TEXT NOT NULL,
    "TypeCostService" TEXT NOT NULL,
    CONSTRAINT "FK_OtherServiceTeachingStaff_ServiceExpense_Id" FOREIGN KEY ("Id") REFERENCES "ServiceExpense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "InvestmentExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_InvestmentExpense" PRIMARY KEY AUTOINCREMENT,
    CONSTRAINT "FK_InvestmentExpense_SpecialExpense_Id" FOREIGN KEY ("Id") REFERENCES "SpecialExpense" ("Id") ON DELETE CASCADE
);


CREATE TABLE "TransferExpense" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TransferExpense" PRIMARY KEY AUTOINCREMENT,
    CONSTRAINT "FK_TransferExpense_SpecialExpense_Id" FOREIGN KEY ("Id") REFERENCES "SpecialExpense" ("Id") ON DELETE CASCADE
);


CREATE INDEX "IX_Discount_StudentModelId" ON "Discount" ("StudentModelId");


CREATE INDEX "IX_Expense_CohortModelId" ON "Expense" ("CohortModelId");


CREATE INDEX "IX_RegistrationModel_CohortModelId" ON "RegistrationModel" ("CohortModelId");


CREATE INDEX "IX_RegistrationModel_StudentId" ON "RegistrationModel" ("StudentId");


CREATE INDEX "IX_SubjectModel_RegistrationModelId" ON "SubjectModel" ("RegistrationModelId");


CREATE INDEX "IX_SubjectModel_TeacherId" ON "SubjectModel" ("TeacherId");


CREATE INDEX "IX_Teacher_LeaderId" ON "Teacher" ("LeaderId");


CREATE INDEX "IX_Teacher_ProgramModelId" ON "Teacher" ("ProgramModelId");


