using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 접근제한자

// 클래스는 => 나, 친구A, 친구B => 학생
// 수학선생, 국어선생님, 과학선생님 => 선생님

// -----------------------------------------------------------

// public (공용) :
// 학교의 운동, 누구나 들어갈 수 있다.
// C#에서 public은 클래스, 메서드, 변수 등이 어디서나 접근이 가능해진다.

// private (개인적인) :
// 학교의 라커, 라커의 주인만 열어볼 수 있다.
// private은 클래스 안에서만 사용이 가능하다. 다른 클래스에서는 접근이 불가능하다.

// protected (보호된) :
// 선생님들만 들어갈 수 있는 교무, 학생들은 들어갈 수 없다.
// 그 클래스나 선생님이라는 클래스를 상속받은 하위클래스만 들어갈 수 있다.

// -----------------------------------------------------------

// internal (내부적인) :
// 학교 건물 내부에 있는것, 학교에 속한 사람들만 사용할 수 있는 것.
// 어셈블리

// protected internal (보호된 내부) :
// 학교 내부에 있는 특별한 방 => 상담소
// 같은 어셈블, 조건 충족했을 때 접근가능

public class School
{
    public string SchoolYard = "SchoolYard";
    private string Locker = "Student's Locker";
    protected string TeachersRoom = "Teacher's room";
    internal string library = "School Library";
    protected internal string Cafeteria = "School Cafeteria";

    public void ShowAccess()
    {
        Debug.Log($"School Yard : {SchoolYard}");
        Debug.Log($"Locker : {Locker}");
        Debug.Log($"TeachersRoom : {TeachersRoom}");
        Debug.Log($"library : {library}");
        Debug.Log($"Cafeteria : {Cafeteria}");

    }
}

public class Classroom : School
{
    public void ShowClassroomAccess()
    {
        SchoolYard = "NONE";
        TeachersRoom = "NONE";
        Debug.Log($"School Yard : {SchoolYard}");
        // Debug.Log($"Locker : {Locker}"); => private이기 때문에 접근 불가!
        Debug.Log($"TeachersRoom : {TeachersRoom}");
        Debug.Log($"library : {library}");
        Debug.Log($"Cafeteria : {Cafeteria}");
    }
}

// Start => OnEnable => Update => FixedUpdate => OnDisable => OnDestroy

public class AccessTester : MonoBehaviour
{
    private void Start()
    {
        School mySchool = new School();
        Classroom myClassroom = new Classroom();

        Debug.Log("Access in School:");
        mySchool.ShowAccess();

        Debug.Log("Access in Classtoom");
        myClassroom.ShowClassroomAccess();
    }
}
