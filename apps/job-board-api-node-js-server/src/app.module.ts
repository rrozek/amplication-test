import { Module } from "@nestjs/common";
import { SkillModule } from "./skill/skill.module";
import { WorkerProfileModule } from "./workerProfile/workerProfile.module";
import { ApplicationModule } from "./application/application.module";
import { WorkerProfileExtraSkillModule } from "./workerProfileExtraSkill/workerProfileExtraSkill.module";
import { JobPostingSkillModule } from "./jobPostingSkill/jobPostingSkill.module";
import { JobPostingModule } from "./jobPosting/jobPosting.module";
import { ExtraSkillModule } from "./extraSkill/extraSkill.module";
import { JobPostingExtraSkillModule } from "./jobPostingExtraSkill/jobPostingExtraSkill.module";
import { WorkerProfileSkillModule } from "./workerProfileSkill/workerProfileSkill.module";
import { UserModule } from "./user/user.module";
import { HealthModule } from "./health/health.module";
import { PrismaModule } from "./prisma/prisma.module";
import { SecretsManagerModule } from "./providers/secrets/secretsManager.module";
import { ServeStaticModule } from "@nestjs/serve-static";
import { ServeStaticOptionsService } from "./serveStaticOptions.service";
import { ConfigModule, ConfigService } from "@nestjs/config";
import { GraphQLModule } from "@nestjs/graphql";
import { ApolloDriver, ApolloDriverConfig } from "@nestjs/apollo";

@Module({
  controllers: [],
  imports: [
    SkillModule,
    WorkerProfileModule,
    ApplicationModule,
    WorkerProfileExtraSkillModule,
    JobPostingSkillModule,
    JobPostingModule,
    ExtraSkillModule,
    JobPostingExtraSkillModule,
    WorkerProfileSkillModule,
    UserModule,
    HealthModule,
    PrismaModule,
    SecretsManagerModule,
    ConfigModule.forRoot({ isGlobal: true }),
    ServeStaticModule.forRootAsync({
      useClass: ServeStaticOptionsService,
    }),
    GraphQLModule.forRootAsync<ApolloDriverConfig>({
      driver: ApolloDriver,
      useFactory: (configService: ConfigService) => {
        const playground = configService.get("GRAPHQL_PLAYGROUND");
        const introspection = configService.get("GRAPHQL_INTROSPECTION");
        return {
          autoSchemaFile: "schema.graphql",
          sortSchema: true,
          playground,
          introspection: playground || introspection,
        };
      },
      inject: [ConfigService],
      imports: [ConfigModule],
    }),
  ],
  providers: [],
})
export class AppModule {}
