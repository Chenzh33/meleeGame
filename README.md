# meleeCombatGameDemo
melee/combo combat system test

* 引擎: Unity 2019.4.12f
* 战斗风格/系统简述：
  * 快节奏的一对多强制清关风格，非常鼓励速杀和连杀，考验操作，较多借鉴忍者龙剑传、鬼泣；
  * 有处决和晕值的设定，用连续不断的攻击将敌人一口气打至气绝状态后，可以使用处决一击必杀；
  * 有能量槽的设定，初始状态时玩家拥有一个单位的能量计量表，计量表不满时能量会随时间缓慢恢复，玩家可以消耗能量使用各种强力的充能招式；
  * 以任意方式击杀敌人时，可以回复满当前计量表的所有能量；
  * 使用处决攻击成功击杀敌人时，可以额外获得一个能量计量表（且已经充满），配合上一条，相当于回复至少一个计量表、至多两个计量表的能量；
  * 使用处决攻击击中敌人时，可以回复一定的能量；
  * 当存在额外的能量计量表时，能量会随时间较快速地自行衰减，直到只存在一个计量表为止。
* 素材借物表（特效等均为自制）
  * mixamo.com的ybot模型和多个动画（用于敌人）
  * frank slash pack，模型+动画（用于主角），由于从一开始使用的就是UE4版的素材（现已有Unity版，后续考虑更换），骨骼不能直接对应，动画出现不少bug，后续虽有一些Unity内手动微调，但刀不能入鞘等bug目前仍存在并未解决
  * scifi gun collection，两种持枪敌人所拿枪的模型（包括手枪和来复枪）
  * tanto knife，持匕首敌人所拿匕首的模型
  * katana sword free，持长刀敌人所拿的刀的模型
* 基本键位：（目前仅支持全键盘，键位配置类似鬼泣4，且暂时不可更改键位配置）:
  * 移动：`W/S/A/D`
  * 近战攻击：`I`
  * 处决攻击/确认：`J`
  * 闪避/取消：`K`
  * 防御：`L`
  * 充能：`Space`（空格键）
  * 主菜单：`Esc`
* 招式表
  
| 招式名（仮） | 按键 | 描述 |
| :----: | :----: | :----: |
| 近战combo A | `IIII` | 快速的四连斩，最后的强力一击可以积累大量晕值并拥有很强的击退效果 |
| 近战combo B | `II.II(Ixn)I` | 在施展一个击退面前敌人的拔刀斩之后，进行一段连绵不绝的具有范围伤害的追击，并以一记强力的拔刀斩收尾。可以通过连按`I`增加追击斩的次数 | 
| 近战combo C | `III.I` | 施展连续旋转两周的大范围斩击，带有不俗的突围和击退效果 |
| 剑气 | 按住`I`，剑身发光后释放 | 斩出一发速度很快、范围较大、具有贯穿效果且具有较强击晕效果的剑气，擅长对付位于远处的敌人。可衔接在任意近战combo的任意攻击后释放。若在任意近战攻击结束瞬间释放，完美释放斩出的利刃投影会首先稍作停留并急速旋转，之后以极快速度向前发射，破坏力和影响范围都会得到大幅强化 |
| 剑气·连斩 | 在剑气后，看准时机按`I`，最多可两次 | 额外斩出最多两发速度极快的剑气，期间可通过方向键调整发射方向。类似目押的机制，太快或太慢按`I`均不会触发后续剑气攻击 |
| 处决·突刺 | `J` | 稍作准备后向前进行短距离的突刺，命中时会进入双方无敌的状态（类似投技），等待片刻（或再次按下`J`）后拔出刀刃可对敌人造成一定伤害并造成击退，对击晕状态的敌人一击必杀。不命中则会产生较大的破绽。不具备击晕值 |
| 处决·落刃 | 长按`J`并释放 | 原地蓄力后向目标敌人头顶跳跃并奋力下刺，接触地面时产生AOE伤害并累计击晕值，之后击倒目标敌人并将其钉在地上（进入处决状态），等待片刻（或再次按下`J`）后拔出刀刃并对敌人造成一定的伤害。对击晕状态的敌人一击必杀 |
| 垫步 | `K` | 垫步闪避，启动时具有一段无敌帧，长按或短按`K`可控制移动的距离，可使用方向键控制垫步方向 |
| 空翻 | 长按`K`之后，按`K` | 在垫步冲刺积累一定的速度后，借势进行一个空翻，具有较长时间的无敌帧，并使角色短暂腾空。可使用方向键控制空翻方向 |
| 空中下坠斩 | 腾空状态时，按`I` | 利落地旋转斩击并落地，可以替代comboA/B/C的第一击并衍生后续连招 |
| 空中落刃 | 腾空状态时，按`J` | 在空中立刻进行下刺攻击，落地时产生AOE伤害，若靠近敌人会进入处决·落刃的处决状态 |
| 防御 | 按住`L` | 招架敌人的攻击，减少收到的伤害、晕值积累以及击退效果。无法招架一些破坏力较强的招式，若在敌人近战攻击/投射物即将命中瞬间按`L`，即可完美化解敌人的攻击，包括普通防御无法进行防御的攻击。角色不受到任何伤害、晕值积累以及击退效果。近战攻击会予以弹反，对敌人产生极大击晕值积累效果并击退，投射物则会原路弹回 |
| 充能 | `Space` | 可配合其他技能按键释放进阶版本的招式 |
| 幻影剑 | `Space` + `I` | *未完成实装，初步设想如下：消耗一定的能量，产生四柄环绕角色的幻影剑，这个招式独立于角色的动作状态机，类似鬼泣的Vergil。若之前已经有一定数量的幻影剑存在，超出的幻影剑将会立即超四周发射，幻影剑可以对敌人造成较长硬直以及较大晕值积累效果。在有幻影剑存在的情况下，任何comboA/B/C的攻击将会触发幻影剑的发射。不同combo中幻影剑的发射模式、消耗数量和效果会有区别* |
| 漩涡 | 按住`I`，剑身发光后按住`Space`并释放`I` | 消耗一定的能量，快速挥刀斩击前方空间并生成一个漩涡，在短时间内对大范围内的敌人持续造成伤害并产生向中心吸引的控制效果，完美释放时，可以加快释放速度、漩涡的大小以及持续时间 |
| 处决·迅刺 | `Space` + `J` | 消耗一定能量，以迅雷不及掩耳之势向前方进行长距离突刺，处决被捕捉的击晕状态的敌人，再次按下`J`可拔出刀刃提前结束处决状态 |
| 处决·雷霆 | `Space` + 长按`J` | 消耗大量能量，蓄力后向前方高高跃起并重击地面，产生大范围AOE伤害、晕值积累以及击退效果，对于范围内击晕状态的敌人具有处决判定 |
| 迅冲斩 | `Space` + `K`，最多可3次 | 消耗一定能量，快速向前方冲刺并斩击，期间角色无敌并可以穿透敌人。最多可连续进行3次，后两次破坏力依次增强 |
| 螺旋天翔斩 | `Space` + 长按`K` | 消耗一定的能量，朝目标敌人快速突进，接触到敌人时旋转并进行一段斩击，之后自身进入腾空状态 |
| 绝对防御 | `Space` + `L` | 消耗一定能量，击退周围敌人并生成一个跟随角色的短时间存在的护罩，护罩将持续产生防御判定并且自动反弹所有敌人的投射物 |

 
