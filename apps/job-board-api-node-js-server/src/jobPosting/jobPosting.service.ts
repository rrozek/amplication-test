import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { JobPostingServiceBase } from "./base/jobPosting.service.base";

@Injectable()
export class JobPostingService extends JobPostingServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
