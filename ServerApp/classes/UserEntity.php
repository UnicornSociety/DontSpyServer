<?php

class UserEntity implements JsonSerializable
{
    protected $id;
    protected $firstname;
    protected $surname;
    protected $email;

    public function __construct(array $data)
    {
        $this->id = $data['id'];
        $this->firstname = $data['firstname'];
        $this->surname = $data['surname'];
        $this->email = $data['email'];
    }

    public function getId()
    {
        return $this->id;
    }

    public function getFirstname()
    {
        return $this->firstname;
    }

    public function getSurname()
    {
        return $this->surname;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function jsonSerialize()
    {
        return [
            'id' => $this->getId(),
            'firstname' => $this->getFirstname(),
            'surname' => $this->getSurname(),
            'email' => $this->getEmail()
        ];
    }
}
