<?php

class UserEntity implements JsonSerializable
{
    protected $id;
    protected $displayname;
    protected $email;

    public function __construct(array $data)
    {
        $this->id = $data['id'];
        $this->displayname = $data['displayname'];
        $this->email = $data['email'];
    }

    public function getId()
    {
        return $this->id;
    }

    public function getDisplayname()
    {
        return $this->displayname;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function jsonSerialize()
    {
        return [
            'id' => $this->getId(),
            'displayname' => $this->getDisplayname(),
            'email' => $this->getEmail()
        ];
    }
}
