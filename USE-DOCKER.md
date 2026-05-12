# Docker ローカル検証手順

## 目的

GitHub Actions を試す前に、ローカルPCで Docker ビルドと実行を確認する手順です。

## 前提条件

- [Docker Desktop](https://www.docker.com/products/docker-desktop) がインストールされていること
- プロジェクトルートでコマンドを実行すること

## Docker イメージのビルド

```bash
docker build -t myserverjob:latest .
```

- `-t myserverjob:latest`: イメージ名とタグを指定
- `.`: カレントディレクトリの Dockerfile を使ってビルド

## Docker コンテナの実行

```bash
docker run --rm myserverjob:latest
```

- `--rm`: コンテナ終了後に自動削除

実行時の出力例:

```text
Hello, World!
Current date and time: 2026-05-12 12:34:56
Current date and time (JST): 2026-05-12 12:34:56
UUID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

## トラブルシューティング

ビルドキャッシュを無効化して再ビルド:

```bash
docker build --no-cache -t myserverjob:latest .
```

詳細ログを表示:

```bash
docker build --progress=plain -t myserverjob:latest .
```

Dockerfile を明示してビルド:

```bash
docker build -f Dockerfile -t myserverjob:latest .
```

## 補足

ECR への push を含む GitHub Actions 連携は [ECR.md](ECR.md) を参照してください。
