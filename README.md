# MyServerJob

## 本プロジェクトについて

.NET 10 で構築されたサーバージョブアプリケーションです。
コンソールアプリ本体（`MyServerJob.App`）と、xUnit を使ったユニットテスト（`MyServerJob.Tests`）で構成されています。

## 本プロジェクトの構成

```
MyServerJob/
├── global.json               # 使用する .NET SDK バージョンの固定 (10.0.203)
├── MyServerJob.slnx          # ソリューションファイル
├── MyServerJob.App/          # コンソールアプリ本体
│   ├── MyServerJob.App.csproj
│   └── Program.cs
└── MyServerJob.Tests/        # ユニットテストプロジェクト (xUnit)
    ├── MyServerJob.Tests.csproj
    └── UnitTest1.cs
```

## VS Code で本プロジェクトを開く

### 前提条件

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) がインストールされていること
- VS Code 拡張機能 **C# Dev Kit** がインストールされていること

### ビルド方法

`Cmd+Shift+P` → **「タスクの実行」** → **「build」** を選択します。

または `Cmd+Shift+B` でデフォルトのビルドタスクを実行できます。

### 実行方法

左側の **実行とデバッグ** パネル（`Cmd+Shift+D`）を開き、**「MyServerJob.App」** を選択して ▶ ボタンを押します。  
ビルドが自動で実行されたあと、アプリが起動します。

### テスト実行方法

- **タスクから実行**: `Cmd+Shift+P` → **「タスクの実行」** → **「test」**
- **テストエクスプローラー**: 左側のビーカーアイコンからテストを一覧表示・個別実行できます

### リリースビルド・配布方法

`Cmd+Shift+P` → **「タスクの実行」** → **「publish」** を選択します。  
ビルド成果物はプロジェクトルートの `publish/` フォルダに出力されます。

## CLI を使う方法

### ビルド方法

```bash
# ソリューション全体をビルド
dotnet build

# アプリのみビルド
dotnet build MyServerJob.App/MyServerJob.App.csproj
```

### 実行方法

```bash
dotnet run --project MyServerJob.App/MyServerJob.App.csproj
```

### テスト実行方法

```bash
dotnet test MyServerJob.Tests/MyServerJob.Tests.csproj
```

### リリースビルド・配布方法

```bash
dotnet publish MyServerJob.App/MyServerJob.App.csproj --configuration Release --output ./publish
```

成果物は `publish/` フォルダに出力されます。このフォルダをそのまま配布してください。

### 受け取った側での実行方法

配布された `publish/` フォルダを受け取った場合、.NET ランタイムのインストール不要な **自己完結型 (self-contained)** ビルドであれば次のように実行できます。

```bash
# macOS / Linux
./MyServerJob.App

# Windows
MyServerJob.App.exe
```

.NET ランタイムが必要な通常ビルドの場合は、[.NET 10 ランタイム](https://dotnet.microsoft.com/download/dotnet/10.0) をインストールしてから実行してください。

```bash
dotnet MyServerJob.App.dll
```

> **自己完結型ビルド** にする場合は publish コマンドに `--self-contained true -r <RID>` を追加します。  
> 例（macOS Apple Silicon）: `dotnet publish ... --self-contained true -r osx-arm64`
