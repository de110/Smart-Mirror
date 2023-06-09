# Smart-Mirror
2020-1 가상 피팅기 팀 프로젝트
스마트 피팅 미러

개발 인원 - 3

실제로 옷을 입어볼 수 없는 상황이 발생하여 옷 선택의 어려움을 느낄 때 이를 해결할 시스템을 제안하고자 하였다.

1. 시스템 구성

    1.1 시스템 구성도
    
    ![시스템_구성도](https://user-images.githubusercontent.com/67581448/234192537-1c1f9697-acf6-409e-a7b3-deaef99e9f72.png)
    
     **<그림 1> 시스템 구성도**
    
    1.2 하드웨어
    
        - 하드웨어는 XBox 360 키넥트(Kinect) 카메라, DFRobot사의 라떼판다(DFR0419), 삼성전자의 S24D300 모니터로 구성된다.

        - 키넥트 카메라에서 제공하는 스켈레톤 트래킹(skeleton tracking)을 통해 사용자의 신체와 동작을 인식한다. 

        - 라떼판다를 사용하여 임베디드 시스템을 구축한다.

        - 모니터를 통해 사용자가 자신의 모습을 확인할 수 있도록 구축된 시스템을 바탕으로 한 사용자의 모습을 보여준다.
        
    1.3 소프트웨어
    
        - Visual Studio 2019 C# 과 Unity를 기반으로 개발하였다.

        - 날씨 정보와 사용자의 표정 인식을 위해 기상청의 날씨 API와 Google Cloud의 Vision API를 사용하였다.
    
2. 착장 추천 알고리즘
    
    본 시스템의 착장 추천 방식은 다음과 같이 진행된다.
    
    ![알고리즘](https://user-images.githubusercontent.com/67581448/234192650-ee6fadb9-2206-4305-909c-279dbff6dc9d.png)
    
    **<그림 2> 착장 추천 알고리즘**
    
    a. 디스플레이에 나타난 사용자의 모습을 인식한다.
    
    b. 사용자가 시작 버튼을 클릭하는 경우 당일의 기온 값을 가져온다.
    
    c. 기온 값을 기준으로 날씨에 어울리는 상의 카테고리를 지정하여 옷 추천을 진행한다.
    
    d. 추천된 옷을 사용자의 모습에 피팅한다.
    
    e. 사용자의 표정을 인식하여 감정을 분석한다.
    
    f. 분석된 감정을 기반으로 옷을 다시 추천하거나, 추천을 종료한다.
    
     - Google Cloud API가 인식할 수 있는 감정의 종류는 총 네 가지(JOY, SORROW, ANGER, SURPRISE)이며, 본 시스템에서는 그 중 JOY 속성을 기준으로 추천을 진행한다.

     - JOY는 다섯 개의 단계로 구분되며, 3단계 이상이 되면 만족스러운 옷이 추천되었다고 판단해 다음 알고리즘으로 이동한다. <br/>
        
        
        | 1단계 | VERY_UNLIKELY |
        | --- | --- |
        | 2단계 | UNLIKELY |
        | 3단계 | POSSIBLE |
        | 4단계 | LIKELY |
        | 5단계 | VERY_LIKELY |
        
        < 표 1 > Google Cloud의 표정 인식에 따른 감정 분석 단계
        

3. 결과

    ![하드웨어_구성](https://user-images.githubusercontent.com/67581448/234192660-a176b574-b7a7-4aef-8560-e13bff280c28.png)

    **<그림3> 하드웨어 구성**

    <그림 3>은 하드웨어의 구성을 보여준다. 키넥트 카메라를 통해 사용자를 인식할 경우 모니터에 사용자의 모습을 나타낸다.
    
    3.1 실제 모습과 의상 간 매칭 정확도

    | Joint | x | y | z |
    | --- | --- | --- | --- |
    | Hip Center | 0.0143 | 0.3787 | 2.5615 |
    | Spine | 0.0172 | 0.4311 | 2.5386 |
    | Shoulder Center | 0.0875 | 0.4904 | 2.6675 |
    | Head | 0.1595 | 0.6158 | 2.7725 |
    | Shoulder Left | 0.5123 | 0.7915 | 2.6100 |
    | Elbow Left | 1.3937 | 0.7348 | 2.5028 |
    | Wrist Left | 2.2714 | 0.6993 | 2.4508 |
    | Hand Left | 2.7255 | 0.6885 | 2.5105 |
    | Shoulder Right | 0.7490 | 0.7778 | 2.7332 |
    | Elbow Right | 1.6274 | 0.6732 | 2.9494 |
    | Wrist Right | 2.3843 | 0.7108 | 3.4324 |
    | Hand Right | 2.8198 | 0.7646 | 3.7476 |
    | Hip Left | 0.3585 | 0.4366 | 2.6532 |
    | Knee Left | 0.3876 | 0.3103 | 2.6863 |
    | Ankle Left | 0.6361 | 0.4893 | 2.2462 |
    | Foot Left | 0.5647 | 0.7711 | 2.5440 |
    | Hip Right | 0.3122 | 0.7661 | 2.7102 |
    | Knee Right | 0.4005 | 0.2913 | 2.7185 |
    | Ankle Right | 0.6459 | 0.4550 | 2.2662 |
    | Foot Right | 0.5212 | 0.6568 | 2.5555 |

    <표 2> 인체의 관절 위치와 매칭된 의상의 관절 위치의 표준편차
        
     의상이 인체에 매칭된 성능을 평가하기 위해서, 키넥트 v1으로 구할 수 있는 20개의 인체의 관절 위치와 매칭된 의상의 관절 위치를 월드 좌표계에서 구하였다.
     
     이후 위치 값인 x, y와 깊이 값인 z에 대한 표준편차 계산을 통하여 평균적으로 어느정도 차이가 있는지 확인하였다.
     
     
     3.2보완점
     
     사용자가 소지하고 있거나 사용자의 취향을 고려한 의상을 반영하고, 인체와 의상과의 매칭 정확도 향상이 요구된다.
