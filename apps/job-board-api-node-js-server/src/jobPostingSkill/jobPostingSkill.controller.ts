import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { JobPostingSkillService } from "./jobPostingSkill.service";
import { JobPostingSkillControllerBase } from "./base/jobPostingSkill.controller.base";

@swagger.ApiTags("jobPostingSkills")
@common.Controller("jobPostingSkills")
export class JobPostingSkillController extends JobPostingSkillControllerBase {
  constructor(protected readonly service: JobPostingSkillService) {
    super(service);
  }
}
