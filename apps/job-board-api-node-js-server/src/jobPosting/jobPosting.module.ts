import { Module } from "@nestjs/common";
import { JobPostingModuleBase } from "./base/jobPosting.module.base";
import { JobPostingService } from "./jobPosting.service";
import { JobPostingController } from "./jobPosting.controller";
import { JobPostingResolver } from "./jobPosting.resolver";

@Module({
  imports: [JobPostingModuleBase],
  controllers: [JobPostingController],
  providers: [JobPostingService, JobPostingResolver],
  exports: [JobPostingService],
})
export class JobPostingModule {}
