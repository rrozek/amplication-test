import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { JobPostingExtraSkillService } from "./jobPostingExtraSkill.service";
import { JobPostingExtraSkillControllerBase } from "./base/jobPostingExtraSkill.controller.base";

@swagger.ApiTags("jobPostingExtraSkills")
@common.Controller("jobPostingExtraSkills")
export class JobPostingExtraSkillController extends JobPostingExtraSkillControllerBase {
  constructor(protected readonly service: JobPostingExtraSkillService) {
    super(service);
  }
}
