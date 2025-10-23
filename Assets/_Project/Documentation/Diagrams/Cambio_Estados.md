```mermaid
flowchart TB
    A[**IdleState**]-->B{**distance<enemy.viewRadius**}
    B--Yes-->C[null]
    C-->A
    B--No-->D[Cambio SeekState]
    D-->E{**distance>enemy.viewRadius**}
    E--No-->F[null]
    E--Yes-->B
    F-->E