import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { JobPostingService } from "./jobPosting.service";
import { JobPostingControllerBase } from "./base/jobPosting.controller.base";

@swagger.ApiTags("jobPostings")
@common.Controller("jobPostings")
export class JobPostingController extends JobPostingControllerBase {
  constructor(protected readonly service: JobPostingService) {
    super(service);
  }
}
