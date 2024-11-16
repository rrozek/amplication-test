import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { WorkerProfileExtraSkillService } from "./workerProfileExtraSkill.service";
import { WorkerProfileExtraSkillControllerBase } from "./base/workerProfileExtraSkill.controller.base";

@swagger.ApiTags("workerProfileExtraSkills")
@common.Controller("workerProfileExtraSkills")
export class WorkerProfileExtraSkillController extends WorkerProfileExtraSkillControllerBase {
  constructor(protected readonly service: WorkerProfileExtraSkillService) {
    super(service);
  }
}
