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
