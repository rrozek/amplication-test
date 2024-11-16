import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { WorkerProfileServiceBase } from "./base/workerProfile.service.base";

@Injectable()
export class WorkerProfileService extends WorkerProfileServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
