import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { WorkerProfileService } from "./workerProfile.service";
import { WorkerProfileControllerBase } from "./base/workerProfile.controller.base";

@swagger.ApiTags("workerProfiles")
@common.Controller("workerProfiles")
export class WorkerProfileController extends WorkerProfileControllerBase {
  constructor(protected readonly service: WorkerProfileService) {
    super(service);
  }
}
