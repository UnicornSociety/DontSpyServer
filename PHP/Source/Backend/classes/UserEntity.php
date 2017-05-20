<?php

class UserEntity implements JsonSerializable
{
    protected $firstname;
    protected $surname;
    protected $eMail;

    public function __construct(array $data)
    {
        $this->firstname = $data['firstname'];
        $this->surname = $data['surname'];
        $this->eMail = $data['eMail'];
    }

    public function getFirstname()
    {
        print_r($this->firstname);
        return $this->firstname;
    }

    public function getSurname()
    {
        return $this->surname;
    }

    public function getEMail()
    {
        return $this->eMail;
    }

    public function jsonSerialize()
    {
        return [
            'firstname' => $this->getFirstname(),
            'surname' => $this->getSurname(),
            'eMail' => $this->getEMail()
        ];
    }
}
