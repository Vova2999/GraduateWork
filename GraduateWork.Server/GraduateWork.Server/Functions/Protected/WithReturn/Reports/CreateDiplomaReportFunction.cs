﻿using GraduateWork.Common.Database;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Reports {
	public class CreateDiplomaReportFunction : HttpProtectedFunctionWithReturn<FileWithContent> {
		public override string NameOfCalledMethod => "CreateDiplomaReport";
		protected override AccessType RequiredAccessType => AccessType.CreateReport;
		private readonly IReportsCreator reportsCreator;

		public CreateDiplomaReportFunction(IDatabaseAuthorizer databaseAuthorizer, IReportsCreator reportsCreator) : base(databaseAuthorizer) {
			this.reportsCreator = reportsCreator;
		}

		protected override FileWithContent Run(NameValues parameters, byte[] requestBody) {
			return reportsCreator.CreateDiploma(requestBody.FromJson<StudentBasedProxy>());
		}
	}
}