import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { JobPostingExtraSkillServiceBase } from "./base/jobPostingExtraSkill.service.base";

@Injectable()
export class JobPostingExtraSkillService extends JobPostingExtraSkillServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
