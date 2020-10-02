# ElementBallGame

## 動作環境
- Windows10
- Unity 2019.4.5f1 (追加：Android)

## ファイルツリー
<pre>
│  .gitignore
│  ElementBallGame-dev.apk
│  ElementBallGame.apk
│  README.md
│  
├─.git
├─Assets
│  ├─EffectExamples                                   // エフェクト用のフォルダ
│  ├─Oculus                                           // Oculus用のフォルダ
│  ├─Plugin                                           // Sqlite用のフォルダ
│  │  └─Android
│  │          libsqlite3.so
│  │
│  ├─Plugins
│  │  └─Android
│  │
│  ├─Resources                                        // ゲームで使用するファイル
│  │  │  Button.prefab
│  │  │  ElementBallNumberPf.prefab
│  │  │  ElementBallPf.prefab
│  │  │  ElementList.prefab
│  │  │  ONSPSettings.asset
│  │  │  OvrAvatarSettings.asset
│  │  │  OVRBuildConfig.asset
│  │  │  OVRPlatformToolSettings.asset
│  │  │  ReactionFormulaList.prefab
│  │  │  ReactionFormulaList_Popup.prefab
│  │  │  
│  │  ├─image                                         // ゲームで使用する画像
│  │  │  │  circle.png
│  │  │  │  honoo_hi_fire.png
│  │  │  │  mark_tenkiu_kaminari.png
│  │  │  │  triangle.png
│  │  │  │  x.png
│  │  │  │  
│  │  │  ├─Button                                     // ボタン用の画像
│  │  │  │      もう一度このステージを遊ぶButton.png
│  │  │  │      ゲーム機能Button.png
│  │  │  │      ステージ選択画面に戻るButton.png
│  │  │  │      タイトル画面に戻るButton.png
│  │  │  │      元素一覧Button.png
│  │  │  │      化学反応式一覧Button.png
│  │  │  │      図鑑機能Button.png
│  │  │  │      
│  │  │  ├─Monster                                    // モンスターの画像
│  │  │  │  │  Cu.png
│  │  │  │  │  Fe.png
│  │  │  │  │  h2.png
│  │  │  │  │  O2.png
│  │  │  │  │  S.png
│  │  │  │  │  
│  │  │  │  └─Materials                               // モンスターのマテリアル
│  │  │  │          Cu.mat
│  │  │  │          Fe.mat
│  │  │  │          h2.mat
│  │  │  │          O2.mat
│  │  │  │          S.mat
│  │  │  │          
│  │  │  ├─StageImage                                 // ステージ選択画面の画像
│  │  │  │      stage1.PNG
│  │  │  │      stage2.PNG
│  │  │  │      stage3.PNG
│  │  │  │      stage4.PNG
│  │  │  │      stage5.PNG
│  │  │  │      stage6.PNG
│  │  │  │      
│  │  │  └─structure                                  // 図鑑用の画像
│  │  │          H2O構造式.png
│  │  │          
│  │  ├─Material                                      // マテリアル用のフォルダ
│  │  │  │  
│  │  │  ├─color                                      // 色用のマテリアル
│  │  │  │      red.mat
│  │  │  │      toumei.mat
│  │  │  │      transparent_white.mat
│  │  │  │      
│  │  │  ├─element                                    // 元素ボール用のマテリアル
│  │  │  │      Ag.mat
│  │  │  │      Ba.mat
│  │  │  │      C.mat
│  │  │  │      Ca.mat
│  │  │  │      Cl.mat
│  │  │  │      Cl2.mat
│  │  │  │      Cu.mat
│  │  │  │      Fe.mat
│  │  │  │      H.mat
│  │  │  │      H2.mat
│  │  │  │      K.mat
│  │  │  │      Mg.mat
│  │  │  │      Na.mat
│  │  │  │      O.mat
│  │  │  │      O2.mat
│  │  │  │      S.mat
│  │  │  │      
│  │  │  └─image                                      // 元素ボール用マテリアルに使用した画像
│  │  │      │  
│  │  │      ├─中和
│  │  │      ├─分解
│  │  │      ├─化合
│  │  │      ├─気体の発生
│  │  │      ├─沈殿
│  │  │      └─還元
│  │  │                  
│  │  └─Model                                         // 3Dモデル用のフォルダ
│  │      │  
│  │      └─Monster                                   // モンスターの3Dモデル用のフォルダ
│  │              Cu.fbx
│  │              Fe.fbx
│  │              h2.fbx
│  │              O2.fbx
│  │              S.fbx
│  │              
│  ├─Scenes                                           // ゲームのScene用のフォルダ
│  │  │  ElementListScene.unity
│  │  │  GameScene.unity
│  │  │  Main.unity
│  │  │  ReactionFormulaListScene.unity
│  │  │  ResultScene.unity
│  │  │  SelectPictureBookScene.unity
│  │  │  SelectStageScene.unity
│  │  │  TitleScene.unity
│  │  │  UserSelectScene.unity
│  │  │  
│  │  ├─Main
│  │  └─Profiles
│  │          
│  ├─Scripts                                          // ゲームで使用するスクリプト用のフォルダ
│  │  │  Buttonprefab.cs
│  │  │  ElementCatch.cs
│  │  │  ElementInfo.cs
│  │  │  GameAdmin.cs
│  │  │  GameSQLController.cs
│  │  │  InitElementBall.cs
│  │  │  InitNextMonster.cs
│  │  │  MakeUser.cs
│  │  │  MonsterInfo.cs
│  │  │  MyTextDB.cs
│  │  │  NewUserButton.cs
│  │  │  NewUserText.cs
│  │  │  OnClickRFButton.cs
│  │  │  OnClickSphere.cs
│  │  │  SampleDataBase.cs
│  │  │  Score.cs
│  │  │  ShowElementList.cs
│  │  │  ShowReactionFormula.cs
│  │  │  ShowResultImage.cs
│  │  │  UserButtoncleck.cs
│  │  │  UserClearDB.txt
│  │  │  UserName.cs
│  │  │  
│  │  ├─Button                                        // ボタン用のスクリプトフォルダ
│  │  │      ActionButton.cs
│  │  │      ExitGameButton.cs
│  │  │      GoElementListButton.cs
│  │  │      GoGameButton.cs
│  │  │      GoReactionFormulaListButton.cs
│  │  │      GoResultButton.cs
│  │  │      GoSelectPictureBookButton.cs
│  │  │      GoSelectStageButton.cs
│  │  │      GoTitleButton.cs
│  │  │      ShowHintButton.cs
│  │  │      
│  │  └─SQLite                                        // Sqlite用のフォルダ
│  │          DataTable.cs
│  │          SqliteDatabase.cs
│  │          
│  ├─StreamingAssets                                  // データベース用のフォルダ
│  │      ElementBallGame.db
│  │      
│  └─TextMesh Pro
│
├─Library
├─Logs
├─Packages
└─ProjectSettings
</pre>