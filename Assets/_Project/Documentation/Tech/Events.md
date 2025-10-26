classDiagram

&nbsp;   class EventManager {

&nbsp;       +Subscribe(eventName: string, listener: Action)

&nbsp;       +Unsubscribe(eventName: string, listener: Action)

&nbsp;       +Trigger(eventName: string)

&nbsp;   }



&nbsp;   class Player {

&nbsp;       +OnHit()

&nbsp;   }



&nbsp;   class UIManager {

&nbsp;       +ShowHit()

&nbsp;   }



&nbsp;   Player --> EventManager 

&nbsp;   UIManager --> EventManager 

