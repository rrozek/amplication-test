import { Module } from "@nestjs/common";
import { WorkerProfileModuleBase } from "./base/workerProfile.module.base";
import { WorkerProfileService } from "./workerProfile.service";
import { WorkerProfileController } from "./workerProfile.controller";
import { WorkerProfileResolver } from "./workerProfile.resolver";

@Module({
  imports: [WorkerProfileModuleBase],
  controllers: [WorkerProfileController],
  providers: [WorkerProfileService, WorkerProfileResolver],
  exports: [WorkerProfileService],
})
export class WorkerProfileModule {}
