# ECR 連携ガイド

## 概要

本プロジェクトでは、release ブランチへ push されたときに GitHub Actions が自動実行されます。

- .NET ビルド
- テスト
- Docker イメージ作成
- AWS ECR への push

対象ワークフロー: `.github/workflows/dotnet-release.yml`

## GitHub 側の設定

GitHub リポジトリで以下を設定します。

1. リポジトリの Settings を開く
2. Secrets and variables > Actions を開く
3. 以下の Repository secrets を追加する

必要な Repository secrets:

- `ECR_REGISTRY`: ECR レジストリ URL
  例: `123456789012.dkr.ecr.ap-northeast-1.amazonaws.com`
- `ECR_REPOSITORY`: ECR リポジトリ名
  例: `myserverjob`
- `AWS_ACCESS_KEY_ID`: ECR push 権限を持つ IAM ユーザーのアクセスキー ID
- `AWS_SECRET_ACCESS_KEY`: 同ユーザーのシークレットアクセスキー

## AWS 側の準備

1. ECR リポジトリを作成
2. IAM ユーザーまたはロールを作成
3. 最小権限で ECR push 権限を付与

必要になる主な権限例:

- `ecr:GetAuthorizationToken`
- `ecr:BatchCheckLayerAvailability`
- `ecr:InitiateLayerUpload`
- `ecr:UploadLayerPart`
- `ecr:CompleteLayerUpload`
- `ecr:PutImage`
- `ecr:BatchGetImage`

## 自動ビルドの動作

- release ブランチに push すると、`.github/workflows/dotnet-release.yml` が起動
- ビルドまたはテストが失敗した場合、その時点でジョブは失敗終了
- 成功した場合のみ Docker イメージが build され、ECR に push される

## 補足

ローカルで Docker を試す手順は [USE-DOCKER.md](USE-DOCKER.md) を参照してください。
