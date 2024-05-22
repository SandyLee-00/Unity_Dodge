# 던전 서바이벌 (Dungeon Survival)

## 📖 목차

**1. 🎥 프로젝트 소개**

**2. 👨‍👨‍👧‍👦 팀원 및 역할**

**3. 📜 와이어프레임**

**4. ✨ 깃 컨벤션**

**5. 💜 기능 구현**

**6. 💡 트러블 슈팅**

**7. 기타 참고사항**

---
    
### 🎥 프로젝트 소개

![리드미 배경화면](https://github.com/SandyLee-00/Unity_Dodge/assets/104573747/a750cd9c-3777-4b4c-9afb-81da52b2a029)
![리드미 인게임 화면](https://github.com/SandyLee-00/Unity_Dodge/assets/104573747/96307546-7d98-418c-b6bc-2ab768615e75)

**던전 서바이벌 (Dungeon Survival)은 밀려오는 몬스터와 공격으로부터**

**생존해 나가는 게임입니다.**

**지정된 시간 동안 버티고 적을 물리치며 점수를 모아 나가세요!**

---

### ⏲️ 개발기간

 **2024.04.16(목) ~ 2024.05.23(목)**

 ---

### 👨‍👨‍👧‍👦 팀원 및 역할

**이서영 - Managers, GameManager, UIManager, SoundManager (동적 생성 및 기능 구현)** 🖥️

**박도현 - Player (플레이어 움직임, 투사체 발사, Player 관련 충돌 처리 등 기능 구현)** 👦

**김희환 - Monster (몬스터 움직임 (Player 추적 형태), 피격 이펙트 및 충돌 처리 구현)** 😈

**김강은 - ObjectPool, Projectile (오브젝트 풀 활용 Projectile 생성 및 반환 구현)** 🧨

---


### 📜 **와이어프레임**

https://drive.google.com/file/d/11qvmqeNqghScZhGCihI8cATSwYtxme9E/view?usp=sharing

---

### ✨ **깃 컨벤션**

**[FEAT] 새 기능 추가**

**[FIX] 버그 수정**

**[UPDATE] 기능 수정 / 업데이트**

**[STOP] 코드 작업하던 중간에 멈추고 커밋남기기**

**[COMMENT] 주석만 추가**

**[REFECTOR] 코드 리팩토링**

**[RESOURCE] Art/Sounds 파일 추가/수정**

---

**💜 기능 구현**

**1. 무한 맵 생성을 통한 Player 주변 맵 확장**

**2. Player의 근처의 랜덤한 지점에서 공격 자동 생성 로직**

**3. Monster가 Player를 추적하는 로직**

**4. Monster의 원거리 공격 구현**

**5. ObjectPool을 통한 Projectile(PlayerBullet, MonsterBullet), Items 구현**

**6. Item 기능 구현 (점수, 체력 회복)**

**7. Skill 기능 구현 (이동속도 증가, 무적)**

**8. Pointer Effector 2D를 이용한 무적공간 생성**


---

### 💡 **트러블 슈팅**

**1️⃣** 

**각자 개발하는 과정에서 MonsterStat과 CharacterStat을 따로 생성하였음.**

**enum 부분이 동일하게 다른 코드에 존재해 오류가 나는 상황이 발생했음.**


**[Solution 🔍]** 

**두 파일을 CharacterStat 하나로 통합하여 해결하였음.**



**2️⃣**

**통합 과정에서 Bullet (투사체) Prefab을 수정하여 사용하다가** 

**Merge 시도를 하니 기존 Bullet과 충돌이 나는 현상이 발생하였음.**


**[Solution 🔍]**  

**수정한 파일을 삭제하고 기존 Bullet을 사용하게 하니 한 사람만 수정해도 영향이 없었음.**



**3️⃣**

 **Monster에게 적중한 투사체를 통해서 Player의 데미지를 가져오는 작업을 수행하고자 했음.**
 

**[Solution 🔍]** 

**Player를 추적하도록 설계되어 있는 Monster에서** 

**미리 가져왔던 Player Object를 통해 AttackSO를 가져와 내부의 공격력 값을 받아와 해결함.**

---
  
### 🖼️ 사용 에셋

**언데드 서바이버 에셋 팩**

https://assetstore.unity.com/packages/2d/undead-survivor-assets-pack-238068
