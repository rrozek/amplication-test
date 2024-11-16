import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { JobPostingSkillServiceBase } from "./base/jobPostingSkill.service.base";

@Injectable()
export class JobPostingSkillService extends JobPostingSkillServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
