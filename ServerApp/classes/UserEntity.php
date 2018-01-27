<?php

class UserEntity implements JsonSerializable
{
    protected $id;
    protected $username;

    public function __construct(array $data)
    {
        $this->id = $data['id'];
        $this->username = $data['username'];
    }

    public function getId()
    {
        return $this->id;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function jsonSerialize()
    {
        return [
            'id' => $this->getId(),
            'displayname' => $this->getUsername()
        ];
    }
}
