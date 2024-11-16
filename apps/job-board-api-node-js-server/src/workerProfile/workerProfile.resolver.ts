import * as graphql from "@nestjs/graphql";
import { WorkerProfileResolverBase } from "./base/workerProfile.resolver.base";
import { WorkerProfile } from "./base/WorkerProfile";
import { WorkerProfileService } from "./workerProfile.service";

@graphql.Resolver(() => WorkerProfile)
export class WorkerProfileResolver extends WorkerProfileResolverBase {
  constructor(protected readonly service: WorkerProfileService) {
    super(service);
  }
}
